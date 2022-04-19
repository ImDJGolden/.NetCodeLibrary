'Import excel references.
'References > COM > Microsoft Excel 16.0 Object Library
Imports Excel = Microsoft.Office.Interop.Excel

Private Function ImportExcel(ByVal file As String) As DataTable
    Dim dt As New DataTable
    Dim colName As String

    Try
        Dim xlApp As Excel.Application = New Excel.Application()
        Dim xlWorkbook As Excel.Workbook = xlApp.Workbooks.Open(file)
        Dim xlWorkSheet As Excel._Worksheet = xlWorkbook.Sheets(1)          'active sheet for data
        Dim xlRange As Excel.Range = xlWorkSheet.UsedRange
        Dim Values As Object(,) = xlRange.Value
        Dim rowCount As Integer = xlRange.Rows.Count
        Dim colCount As Integer = xlRange.Columns.Count

        'COLUMNS
        For i As Integer = 1 To colCount
            'start index Columns is row 1
            colName = Convert.ToString(Values(1, i))

            If colName IsNot Nothing OrElse colName <> "" Then
                dt.Columns.Add(colName)
            End If
        Next

        'ROWS
        For r As Integer = 2 To rowCount
            'start index Data is row 2
            Dim row As DataRow = dt.NewRow()

            For c As Integer = 1 To colCount
                Dim field As String = Convert.ToString(Values(r, c))
                row(c - 1) = field
            Next

            dt.Rows.Add(row)
        Next

        'cleanup
        GC.Collect()
        GC.WaitForPendingFinalizers()
        'release COM Objects to kill Excel process from running in the background
        Marshal.ReleaseComObject(xlRange)
        Marshal.ReleaseComObject(xlWorkSheet)
        'close and release
        xlWorkbook.Close()
        Marshal.ReleaseComObject(xlWorkbook)
        'quit and release
        xlApp.Quit()
        Marshal.ReleaseComObject(xlApp)

    Catch ex As Exception
        Throw
    End Try

    Return dt
End Function