// Export DataTable to CSV file

public string ExportPath = Path.Combine("", "Output.csv")

public void ExportCsv(DataTable dt)
{
    try {
        if (dt.Rows.Count != 0) {
            try {
                //Read Rows into lines of string to export to csv
                List<string> CsvExportLines = new List<string>();

                foreach (DataRow row in dt.Rows) {
                    List<string> valuesInOrder = new List<string>();

                    foreach (DataColumn col in columnsInOrder) {
                        if (!row.IsNewRow) {
                            valuesInOrder.Add(row.Cells[col.Index].Value.ToString());
                        }
                    }

                    CsvExportLines.Add(string.Join(";", valuesInOrder.ToArray()));
                }
                
                StreamWriter Output = File.AppendText(ExportPath);
                
                try {
                    for (int i = 0; i <= CsvExportLines.Count - 1; i++) {
                        Output.WriteLine(CsvExportLines[i]) ;
                    }

                    //Data Exported Succesfully
                }
                catch (Exception ex) {
                    throw;
                }
                finally {
                    Output.Close();
                }
            }
            catch (Exception ex) {
                throw;
            }
        }
        else {
            //No Data in DataTable
        }
    }
    catch (Exception ex) {
        throw;
    }
}