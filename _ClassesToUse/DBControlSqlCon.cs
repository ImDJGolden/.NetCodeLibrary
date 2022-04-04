public class DBControl
{
    public static string mServer = "";
    public static string mDatabase = "";
    public static string mCS = $"";

    public SqlConnection OpenConnection()
    {
        SqlConnection cnn = new SqlConnection(mCS);

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

    public bool CloseConnection(SqlConnection cnn)
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

    public DataTable GetDataTable(string sql)
    {
        SqlConnection cnn = new SqlConnection(mCS);
        SqlCommand cmd = new SqlCommand(sql, cnn);

        DataTable dt = new DataTable();

        try 
        {
            cnn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
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

    public DataTable GetDataTable(SqlConnection cnn, string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, cnn);

        DataTable dt = new DataTable();

        try 
        {
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception) 
        {
            throw;
        }
        return dt;
    }

    public DataTable GetDataTable(SqlCommand cmd, string sql)
    {
        cmd.CommandText = sql;

        DataTable dt = new DataTable();

        try 
        {
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception) 
        {
            throw;
        }
        return dt;
    }

    public bool UpdateDataTable(string sql)
    {
        SqlConnection cnn = new SqlConnection(mCS);
        SqlCommand cmd = new SqlCommand(sql, cnn);

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