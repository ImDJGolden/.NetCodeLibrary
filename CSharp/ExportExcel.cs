//Write dt to excel file
using Excel = Microsoft.Office.Interop.Excel.Application;

class x 
{
    private bool ExportExcel(DataTable dt)
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
}