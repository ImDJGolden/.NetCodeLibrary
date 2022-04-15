public static DataTable ImportExcel()
{
    //Excel != 0-based --> start index = 1
    //https://www.csharp-console-examples.com/general/c-read-excel-file-into-datatable/
    //https://coderwall.com/p/app3ya/read-excel-file-in-c
    //https://codedocu.com/Details_Mobile?d=2401&a=8&f=396&l=0&v=m&t=Solved:-Reading-Excel-is-very-slow
    try
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(importExcelPath);
        Excel._Worksheet xlWorkSheet = xlWorkbook.Sheets[importExcelSheet];
        Excel.Range xlRange = xlWorkSheet.UsedRange;                            //Gets cells that at anytime contained data.

        object[,] values = xlRange.Value;

        //https://docs.microsoft.com/en-us/office/vba/api/excel.range.text
        //The Text property is most often used for a range of one cell.If the range includes more than one cell,
        //the Text property returns Null, except when all the cells in the range have identical contents and formats.

        //If the contents of the cell is wider than the width available for display, the Text property will modify the displayed value.

        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;

        DataTable dt = new DataTable();

        //Get Columns
        for (int i = 1; i <= colCount; i++)
        {
            string colName = Convert.ToString(values[2, i]);

            if (colName != null || colName != "")
            {
                dt.Columns.Add(colName);
                colsData.Add(colName);
            }
        }

        //Get Rows
        for (int r = importExcelStartIndex; r <= rowCount; r++)
        {
            DataRow row = dt.NewRow();

            for (int c = 1; c <= colCount; c++)
            {
                string field = Convert.ToString(values[r, c]);
                        
                //Excel index = c# + 1
                row[c - 1] = field;
            }

            dt.Rows.Add(row);
        }

        // Cleanup
        GC.Collect();
        GC.WaitForPendingFinalizers();
        // Release COM Objects to kill excel process from running in the background
        Marshal.ReleaseComObject(xlRange);
        Marshal.ReleaseComObject(xlWorkSheet);
        // Close and release
        xlWorkbook.Close();
        Marshal.ReleaseComObject(xlWorkbook);
        // Quit and release
        xlApp.Quit();
        Marshal.ReleaseComObject(xlApp);

        return dt;
    }
    catch (Exception)
    {
        throw;
    }
}