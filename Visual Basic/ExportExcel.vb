'Exporteer dt naar Excel
Imports Excel = Microsoft.Office.Interop.Excel

Private Function ExportExcel(ByVal file As String) As Boolean
        Dim xlApp As Excel.Application = New Excel.Application
        Dim xlWorkbook As Excel.Workbook
        Dim xlWorksheet As Excel.Worksheet

        xlWorkbook = xlApp.Workbooks.Add()
        xlWorksheet = xlWorkbook.ActiveSheet()

        Dim dc As DataColumn
        Dim dr As DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        Dim xlIndex As Integer = 0

        Try

            '   [COLUMNS]
            For Each dc In dtEndExcel.Columns
                'code here
            Next

            '   [ROWS]
            For Each dr In dtEndExcel.Rows
                rowIndex += 1
                colIndex = 0
                For Each dc In dtEndExcel.Columns
                    'code here
                Next
            Next

            xlWorksheet.Columns.AutoFit()
            xlWorkbook.SaveAs(file)

            xlWorkbook.Close()
            xlApp.Quit()

            Return True
        Catch ex As Exception
            Return False
            Throw
        End Try
    End Function