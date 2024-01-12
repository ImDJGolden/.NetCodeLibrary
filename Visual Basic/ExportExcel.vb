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



    '--------------------------------------------------------------------------------

    Private Sub ExportAnalyseAKVK2(dtVK As DataTable, dtAK As DataTable, dtVK_Err As DataTable, dtProd_Err As DataTable, dtDVK_VK As DataTable, dtDVK_AK As DataTable, dtDVK_VK_Err As DataTable)
    'Versie 2 AK VK Analyse export
    Dim arr As Object(,) = New Object(,) {}
    Dim c1 As Excel.Range
    Dim c2 As Excel.Range

    Me.pbStatus.Minimum = 0
    Me.pbStatus.Maximum = 6
    Me.pbStatus.Value = 0

    Try
        'Create Excel application
        Dim objApp As Excel.Application
        Dim objBook As Excel.Workbook
        Dim objSheet As Excel.Worksheet
        Dim range As Excel.Range

        objApp = CreateObject("Excel.Application")

        objBook = objApp.Workbooks.Add

        'Add Excel Tabs
        Dim sh_DVK_VK_Err As Excel.Worksheet = objBook.Worksheets.Add
        Dim sh_DVK_AK As Excel.Worksheet = objBook.Worksheets.Add
        Dim sh_DVK_VK As Excel.Worksheet = objBook.Worksheets.Add
        Dim sh_Prod_Err As Excel.Worksheet = objBook.Worksheets.Add
        Dim sh_VK_Err As Excel.Worksheet = objBook.Worksheets.Add
        Dim sh_AK As Excel.Worksheet = objBook.Worksheets.Add
        Dim sh_VK As Excel.Worksheet = objBook.Worksheets.Add

        'Delete default Tab
        CType(objBook.Sheets("Blad1"), Excel.Worksheet).Delete()

        '----- VERKOOP -----
        objSheet = sh_VK                                                                                    'Set Active Tab
        objSheet.Name = "Verkoop"                                                                           'Rename Tab

        arr = ArrayExportAnalyseVKAK(dtVK)                                                                  'Convert Datatable to Array

        'Data
        c1 = CType(sh_VK.Cells(1, 1), Excel.Range)                                                          'Set cell 1 Range (left top)
        c2 = CType(sh_VK.Cells(1 + dtVK.Rows.Count, dtVK.Columns.Count), Excel.Range)                       'Set cell 2 Range (right bottom)
        range = sh_VK.Range(c1, c2)                                                                         'Set Range Tab
        range.Value = arr                                                                                   'Fill Range with Array

        'Style
        objSheet.Columns.AutoFit()                                                                          'Auto Fit columns
        objSheet.Rows(1).Font.Bold = True                                                                   'Make Row 1 (Headers) Bold
        objSheet.Activate()                                                                                 '<
        objSheet.Application.ActiveWindow.SplitRow = 1                                                      'Fix Top Row
        objSheet.Application.ActiveWindow.FreezePanes = True                                                '>
        For r As Integer = 1 To dtVK.Rows.Count                                                             '<
            c1 = objSheet.Cells(r + 1, 1)                                                                   '
            c2 = objSheet.Cells(r + 1, dtVK.Columns.Count)                                                  '
            If r Mod 2 Then                                                                                 '
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan                                     'Set Alternating Row Style
            Else                                                                                            '
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue                                  '
            End If                                                                                          '
        Next                                                                                                '>

        Me.pbStatus.Increment(1)                                                                            'Move ProgressBar

        '----- AANKOOP -----
        objSheet = sh_AK
        objSheet.Name = "Aankoop"

        arr = ArrayExportAnalyseVKAK(dtAK)

        c1 = CType(sh_AK.Cells(1, 1), Excel.Range)
        c2 = CType(sh_AK.Cells(1 + dtAK.Rows.Count, dtAK.Columns.Count), Excel.Range)
        range = sh_AK.Range(c1, c2)
        range.Value = arr

        objSheet.Columns.AutoFit()
        objSheet.Rows(1).Font.Bold = True
        objSheet.Activate()
        objSheet.Application.ActiveWindow.SplitRow = 1
        objSheet.Application.ActiveWindow.FreezePanes = True
        For r As Integer = 1 To dtAK.Rows.Count
            c1 = objSheet.Cells(r + 1, 1)
            c2 = objSheet.Cells(r + 1, dtAK.Columns.Count)
            If r Mod 2 Then
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan
            Else
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue
            End If
        Next

        Me.pbStatus.Increment(1)

        '----- VERKOOP ERROR -----
        objSheet = sh_VK_Err
        objSheet.Name = "VK Error"

        arr = ArrayExportAnalyseVKAK(dtVK_Err)

        c1 = CType(sh_VK_Err.Cells(1, 1), Excel.Range)
        c2 = CType(sh_VK_Err.Cells(1 + dtVK_Err.Rows.Count, dtVK_Err.Columns.Count), Excel.Range)
        range = sh_VK_Err.Range(c1, c2)
        range.Value = arr

        objSheet.Columns.AutoFit()
        objSheet.Rows(1).Font.Bold = True
        objSheet.Activate()
        objSheet.Application.ActiveWindow.SplitRow = 1
        objSheet.Application.ActiveWindow.FreezePanes = True
        For r As Integer = 1 To dtVK_Err.Rows.Count
            c1 = objSheet.Cells(r + 1, 1)
            c2 = objSheet.Cells(r + 1, dtVK_Err.Columns.Count)
            If r Mod 2 Then
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan
            Else
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue
            End If
        Next

        Me.pbStatus.Increment(1)

        '----- PRODUCTIE ERROR -----
        objSheet = sh_Prod_Err
        objSheet.Name = "Prod Error"

        arr = ArrayExportAnalyseVKAK(dtProd_Err)

        c1 = CType(sh_Prod_Err.Cells(1, 1), Excel.Range)
        c2 = CType(sh_Prod_Err.Cells(1 + dtProd_Err.Rows.Count, dtProd_Err.Columns.Count), Excel.Range)
        range = sh_Prod_Err.Range(c1, c2)
        range.Value = arr

        objSheet.Columns.AutoFit()
        objSheet.Rows(1).Font.Bold = True
        objSheet.Activate()
        objSheet.Application.ActiveWindow.SplitRow = 1
        objSheet.Application.ActiveWindow.FreezePanes = True
        For r As Integer = 1 To dtProd_Err.Rows.Count
            c1 = objSheet.Cells(r + 1, 1)
            c2 = objSheet.Cells(r + 1, dtProd_Err.Columns.Count)
            If r Mod 2 Then
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan
            Else
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue
            End If
        Next

        Me.pbStatus.Increment(1)

        '----- DOORVERKOOP VERKOOP -----
        objSheet = sh_DVK_VK
        objSheet.Name = "DVK Verkoop"

        arr = ArrayExportAnalyseVKAK(dtDVK_VK)

        c1 = CType(sh_DVK_VK.Cells(1, 1), Excel.Range)
        c2 = CType(sh_DVK_VK.Cells(1 + dtDVK_VK.Rows.Count, dtDVK_VK.Columns.Count), Excel.Range)
        range = sh_DVK_VK.Range(c1, c2)
        range.Value = arr

        objSheet.Columns.AutoFit()
        objSheet.Rows(1).Font.Bold = True
        objSheet.Activate()
        objSheet.Application.ActiveWindow.SplitRow = 1
        objSheet.Application.ActiveWindow.FreezePanes = True
        For r As Integer = 1 To dtDVK_VK.Rows.Count
            c1 = objSheet.Cells(r + 1, 1)
            c2 = objSheet.Cells(r + 1, dtDVK_VK.Columns.Count)
            If r Mod 2 Then
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan
            Else
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue
            End If
        Next

        Me.pbStatus.Increment(1)

        '----- DOORVERKOOP AANKOOP -----
        objSheet = sh_DVK_AK
        objSheet.Name = "DVK Aankoop"

        arr = ArrayExportAnalyseVKAK(dtDVK_AK)

        c1 = CType(sh_DVK_AK.Cells(1, 1), Excel.Range)
        c2 = CType(sh_DVK_AK.Cells(1 + dtDVK_AK.Rows.Count, dtDVK_AK.Columns.Count), Excel.Range)
        range = sh_DVK_AK.Range(c1, c2)
        range.Value = arr

        objSheet.Columns.AutoFit()
        objSheet.Rows(1).Font.Bold = True
        objSheet.Activate()
        objSheet.Application.ActiveWindow.SplitRow = 1
        objSheet.Application.ActiveWindow.FreezePanes = True
        For r As Integer = 1 To dtDVK_AK.Rows.Count
            c1 = objSheet.Cells(r + 1, 1)
            c2 = objSheet.Cells(r + 1, dtDVK_AK.Columns.Count)
            If r Mod 2 Then
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan
            Else
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue
            End If
        Next

        Me.pbStatus.Increment(1)

        '----- DOORVERKOOP VERKOOP ERROR -----
        objSheet = sh_DVK_VK_Err
        objSheet.Name = "DVK VK Error"

        arr = ArrayExportAnalyseVKAK(dtDVK_VK_Err)

        c1 = CType(sh_DVK_VK_Err.Cells(1, 1), Excel.Range)
        c2 = CType(sh_DVK_VK_Err.Cells(1 + dtDVK_VK_Err.Rows.Count, dtDVK_VK_Err.Columns.Count), Excel.Range)
        range = sh_DVK_VK_Err.Range(c1, c2)
        range.Value = arr

        objSheet.Columns.AutoFit()
        objSheet.Rows(1).Font.Bold = True
        objSheet.Activate()
        objSheet.Application.ActiveWindow.SplitRow = 1
        objSheet.Application.ActiveWindow.FreezePanes = True
        For r As Integer = 1 To dtDVK_VK_Err.Rows.Count
            c1 = objSheet.Cells(r + 1, 1)
            c2 = objSheet.Cells(r + 1, dtDVK_VK_Err.Columns.Count)
            If r Mod 2 Then
                objSheet.Range(c1, c2).Interior.Color = Color.LightCyan
            Else
                objSheet.Range(c1, c2).Interior.Color = Color.LightSkyBlue
            End If
        Next

        Me.pbStatus.Increment(1)

        'Set Tab 1 as active
        objSheet = sh_VK
        objSheet.Activate()

        '----- Save Excel -----
        Dim filename As String = ""
        Dim savefile As New SaveFileDialog
        savefile.AddExtension = True
        savefile.DefaultExt = "xlsx"
        savefile.Filter = "XLSX bestanden (*.xlsx) |*.xlsx|Alle bestanden(*.*) |*.*"
        savefile.OverwritePrompt = True
        'savefile.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        savefile.Title = filename
        savefile.FileName = filename
        If savefile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                filename = savefile.FileName
                objApp.DisplayAlerts = False
                objBook.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, System.Reflection.Missing.Value, False, False, Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, True, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        'Close Excel application
        range = Nothing
        objSheet = Nothing
        objBook.Close(False, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        objBook = Nothing
        objApp.Quit()
        objApp = Nothing

        GC.Collect()
        GC.WaitForPendingFinalizers()

        'Open Excel file
        If File.Exists(filename) Then
            Dim dres As DialogResult = MessageBox.Show("Opgeslagen Excel document openen?", "Openen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dres = DialogResult.Yes Then
                Process.Start(filename)
            End If
        End If
    Catch ex As Exception
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Log.Write(ex.Message)
    End Try
End Sub