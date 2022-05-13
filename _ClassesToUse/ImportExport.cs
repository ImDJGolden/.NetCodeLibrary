using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

public static class ImportExport
{
    #region Import
    public static DataTable ImportExcel(string filePathExcel)
    //Import data from excel file into datatable
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

    public static DataTable ImportCsv_NoHeaders(string filePathCsv)
    //Import data from CSV file with no headers into datatable
    {
        DataTable dt = new DataTable();
        string[] delimiters = new string[] { ";", "," };

        try 
        {
            using (TextFieldParser csv = new TextFieldParser(filePathCsv))
            {
                csv.SetDelimiters(delimiters);
                csv.HasFieldsEnclosedInQuotes = true;

                //  [ADD COLUMNS - Manual]
                dt.Columns.AddRange(new DataColumn[] {
                    new DataColumn("col name here", typeof(string)),
                    //...
                });

                //  [ADD COLUMNS - Automatic]
                for (int c = 0; c <= csv.lines.Count - 1; c++) 
                {
                    dt.Columns.add($"Column {c}");
                }

                //  [ROWS]
                while (!csv.EndOfData) 
                {
                    string[] cells = csv.ReadFields();
                    DataRow dr = dt.NewRow();

                    for (int r = 0; r <= cells.Length - 1; r++)
                    {
                        if (cells[r] != null)
                        {
                            dr(r) = cells[r];
                        }
                        else 
                        {
                            //null value found
                            dr(r) = "";
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }

        return dt;
    }
    
    public static DataTable ImportCsv_Headers(string filePathCsv)
    //Import data from CSV file with headers into datatable
    {
        DataTable dt = new DataTable();
        string[] delimiters = new string[] { ";", "," };

        try 
        {
            using (TextFieldParser csv = new TextFieldParser(filePathCsv))
            {
                csv.SetDelimiters(delimiters);
                csv.HasFieldsEnclosedInQuotes = true;

                //  [COLUMNS]
                string[] cols = csv.ReadFields();

                foreach (string c in cols)
                {
                    DataColumn dc = new DataColumn(c);
                    dt.Columns.Add(dc);
                }

                //  [ROWS]
                while (!csv.EndOfData) 
                {
                    string[] cells = csv.ReadFields();
                    DataRow dr = dt.NewRow();

                    for (int r = 0; r <= cells.Length - 1; r++)
                    {
                        if (cells[r] != null)
                        {
                            dr(r) = cells[r];
                        }
                        else 
                        {
                            //null value found
                            dr(r) = "";
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }

        return dt;
    }
    #endregion

    #region Export
    public static bool ExportExcel(DataTable dt)
    //Export data from datatable to Excel file
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook;
        Excel.Worksheet xlWorksheet;

        xlWorkbook = xlApp.Workbook.Add();
        xlWorksheet = xlWorkbook.ActiveSheet();

        int colIndex = 0;
        int rowIndex = 0;

        try
        {
            //  [COLUMNS]
            foreach (DataColumn dc in dt) 
            {
                //  ***code here***
                switch(dc.ColumnName)
                {
                    case "":
                        colIndex += 1;
                        xlApp.Cells(1, colIndex) = "";
                        break;

                    //...

                    case default:
                        break;
                }
            }

            //  [ROWS]
            foreach (DataRow dr in dt)
            {
                rowIndex += 1;
                colIndex = 0;

                foreach (DataColumn dc in dt)
                {
                    //  ***code here***
                    switch(dc.ColumnName)
                    {
                        case "":
                            colIndex += 1;
                            xlApp.Cells(rowIndex + 1, colIndex) = dr("");
                            break;

                        //...

                        case default:
                            break;
                    }
                }
            }

            xlWorksheet.Columns.AutoFit();
            xlWorkbook.SaveAs("filePath here");
            xlWorkbook.Close();
            xlApp.Quit();

            return true;
        }
        catch 
        {
            return false;
            throw;
        }
    }
    
    public static void ExportCsv(DataTable dt)
    //Export data from datatable to CSV file 
    {
        string filePathExport = "";
        StreamWriter sw = File.AppendText(filePathExport);
        List<string> export = new List<string>();

        try
        {
            //  [COLUMNS]
            foreach (DataColumn dc in dt.Columns) 
            {
                export.Add(string.Join(";", dc.ColumnName));
            }

            //  [ROWS]
            foreach (DataRow dr in dt.Rows) 
            {
                foreach (DataColumn dc in dt.Columns) 
                {
                    export.Add(string.Join(";", dr.Cells[dc.index].value.ToString()));
                }
            }

            for (int i = 0; i <= export.Count - 1; i++)
            {
                sw.WriteLine(export[i]);
            }
        }
        catch
        {
            throw;
        }
        finally 
        {
            sw.Close();
        }
    }
    
    public static void ExportCsv(DataRow dr)
    //Export data from a single datarow to CSV file
    {
        string filePathExport = "";
        StreamWriter sw = File.AppendText(filePathExport);

        try 
        {
            sw.WriteLine(dr[0].ToString);
        }
        catch 
        {
            throw;
        }
        finally 
        {
            sw.Close();
        }
    }
    #endregion
}