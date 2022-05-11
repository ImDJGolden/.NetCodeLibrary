using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

public static class ImportExcel 
{
    //import data from excel into DataTabel

    public static DataTable ImportExcel(string filePathExcel)
    {
        DataTable dt = new DataTable();
        int sheet    = 0;   //number Excelsheet
        int colIndex = 0;   //index Column start
        int rowIndex = 0;   //index Row start

        try 
        {
            Excel.Application   xlApp           = new Excel.Application();
            Excel.Workbook      xlWorkbook      = xlApp.Workbook.Open(filePathExcel);
            Excel._Worksheet    xlWorksheet     = xlWorkbook.Sheets[sheet];
            Excel.Range         xlRange         = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            object[,] values = xlRange.Value;

            string col;
            string cell;
            
            //  [COLUMNS]
            for (int c = colIndex - 1; c <= colCount; c++)
            {
                col = values[rowIndex - 1, c].ToString();
                if (col != null || col != "")
                {
                    col = col.Trim();
                    dt.columns.Add(col);
                }
            }

            //  [ROWS]
            for (int r = rowIndex - 1; r <= rowCount; r++)
            {
                DataRow row = dt.NewRow();
                for (int c = colIndex - 1; c<= colCount; c++)
                {
                    if (values[r, c] != null) 
                    {
                        cell = values[r, c].ToString();
                    }
                    else 
                    {
                        cell = "";
                    }
                    row[c - 1] = cell;
                }
                dt.Rows.Add(row);
            }

            // Cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // Release COM Objects to kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            // Close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            // Quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
        catch(Exception ex)
        {
            throw;
        }

        return dt;
    }
}