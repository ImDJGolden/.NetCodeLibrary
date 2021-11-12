Public ExportPath As String = Path.Combine("", "Output.csv")

Public Sub ExportCsv(ByVal dt As DataTable)
    Try
        If dt.Rows.Count <> 0 Then
            Try
                'Read Rows into lines of string to export to csv
                Dim CsvExportLines As List(Of String) = New List(Of String)()

                For Each row As DataRow In dt.Rows
                    Dim valuesInOrder As List(Of String) = New List(Of String)()

                    For Each col As DataColumn In columnsInOrder
                        If Not row.IsNewRow Then
                            valuesInOrder.Add(row.Cells(col.Index).Value.ToString())
                        End If
                    Next

                    CsvExportLines.Add(String.Join(";", valuesInOrder.ToArray()))
                Next
                Dim Output As StreamWriter = File.AppendText(ExportPath)

                Try
                    For i As Integer = 0 To CsvExportLines.Count - 1
                        Output.WriteLine(CsvExportLines(i))
                    Next

                    'Data exported succesfully
                Catch ex As Exception
                    Throw
                Finally
                    Output.Close()
                End Try

            Catch ex As Exception
                Throw
            End Try
        Else
            'No Data in DataTable
        End If
    Catch ex As Exception
        Throw
    End Try
End Sub