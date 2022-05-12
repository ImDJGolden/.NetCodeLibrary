// CSV File Without Headers
namespace ImportCSV
{
    public partial class x 
    {
        private DataTable GetDataTableFromCSV(string filename)
        {
            DataTable CsvData = new DataTable();

            try {
                using (TextFieldParser csvReader = new TextFieldParser(filename)) {
                    csvReader.SetDelimiters(new string[] { ";" });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    // Add Columns
                    CsvData.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Column Name here", typeof(string))
                    });

                    // Read data from CSV
                    while (!csvReader.EndOfData) {
                        string[] fieldData = csvReader.ReadFields();
                        DataRow dr = CsvData.NewRow();

                        for (int i = 0; i <= fieldData.Length - 1; i++) {
                            if (fieldData[i] == null) {
                                //Null value in csv found
                            }
                            else{
                                dr(i) = fieldData[i];
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw;
            }

            return CsvData;
        }

        // CSV File With Headers
        private DataTable GetDataTableFromCSV(string filename)
        {
            DataTable CsvData = new DataTable();

            try {
                using (TextFieldParser csvReader = new TextFieldParser(filename)) {
                    csvReader.SetDelimiters(new string[] { ";" });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    // Read Columns from CSV
                    string[] colFieds = csvReader.ReadFields();

                    foreach (string column in colFieds) {
                        DataColumn datacolumn = new DataColumn(column);
                        CsvData.Columns.Add(datacolumn);
                    }

                    // Read data from CSV
                    while (!csvReader.EndOfData) {
                        string[] fieldData = csvReader.ReadFields();
                        DataRow dr = CsvData.NewRow();

                        for (int i = 0; i <= fieldData.Length - 1; i++) {
                            if (fieldData[i] == null) {
                                //Null value found in csv
                            }
                            else {
                                dr(i) = fieldData[i];
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw;
            }

            return CsvData;
        }
    }
}
