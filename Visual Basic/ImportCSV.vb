'CSV File Without Headers
Private Function GetDataTableFromCSV(ByVal filename As String) As DataTable
    Dim CsvData As DataTable = New DataTable()

    Try
        Using csvReader As TextFieldParser = New TextFieldParser(filename)
            csvReader.SetDelimiters(New String() {";"})
            csvReader.HasFieldsEnclosedInQuotes = True
            
            'Add Columns
            CsvData.Columns.AddRange(New DataColumn() {
                New DataColumn("Column Name here", GetType(String))
            })

            'Read data from CSV
            While Not csvReader.EndOfData
                Dim fieldData As String() = csvReader.ReadFields()
                Dim dr As DataRow = CsvData.NewRow()

                For i As Integer = 0 To fieldData.Length - 1
                    If fieldData(i) = Nothing Then
                        'Null value found in CSV.
                        'Add error handeling
                    Else
                        dr(i) = fieldData(i)
                    End If
                Next
            End While
        End Using
    Catch ex As Exception
    
    End Try

    Return CsvData
End Function


'CSV File With Headers
Private Function GetDataTableFromCSV(ByVal filename As String) As DataTable
    Dim CsvData As DataTable = New DataTable()

    Try
        Using csvReader As TextFieldParser = New TextFieldParser(filename)
            csvReader.SetDelimiters(New String() {";"})
            csvReader.HasFieldsEnclosedInQuotes = True

            'Read Columns from CSV
            Dim colFieds As String() = csvReader.ReadFields()
            
            For Each column As String in colFieds
                Dim datacolumn As DataColumn = new DataColumn(column)
                CsvData.Columns.Add(datacolumn)
            Next

            'Read data from CSV
            While Not csvReader.EndOfData
                Dim fieldData As String() = csvReader.ReadFields()
                Dim dr As DataRow = CsvData.NewRow()

                For i As Integer = 0 To fieldData.Length - 1
                    If fieldData(i) = Nothing Then
                        'Null value found in CSV.
                        'Add error handeling
                    Else
                        dr(i) = fieldData(i)
                    End If
                Next
            End While
        End Using
    Catch ex As Exception
    
    End Try

    Return CsvData
End Function