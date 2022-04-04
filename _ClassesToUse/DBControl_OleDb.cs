public class DBControl 
{
    public static string mCS = "";
    
    public OleDbConnection OpenConnection()
    {
        OleDbConnection cnn = new OleDbConnection(mCS);

        try
        {
            cnn.Open();
        }
        catch (Exception)
        {
            throw;
        }
        return cnn;
    }

    public bool CloseConnection(OleDbConnection cnn)
    {
        try
        {
            cnn.Close();
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }

    public static DataTable GetDataTable(string sql)
    {
        OleDbConnection cnn = new OleDbConnection(mCS);
        OleDbCommand cmd = new OleDbCommand(sql, cnn);
        DataTable dt = new DataTable();

        try
        {
            cnn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            oda.Fill(dt);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cnn.Close();
        }
        return dt;
    }

    public bool UpdateDatabase(string sql)
    {
        OleDbConnection cnn = new OleDbConnection(mCS);
        OleDbCommand cmd = new OleDbCommand(sql, cnn);
        int result;

        try
        {
            cnn.Open();
            result = cmd.ExecuteNonQuery();

            if (result < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cnn.Close();            
        }
    }
}