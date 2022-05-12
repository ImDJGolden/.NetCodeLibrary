using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

//DB Connection Templates
namespace x 
{
    class x 
    {
        public static string mServer = "";
        public static string mDatabase = "";
        public static string mCS = $@"Server={mServer};Database={mDatabase};User Id=;Password="; //Add User and Password

        public SqlConnection OpenConnection()
        {
            SqlConnection cnn = new SqlConnection(mCS);
            
            try {
                cnn.Open();
            }
            catch (Exception) {
                throw;
            }
            return cnn;
        }

        public bool CloseConnection(SqlConnection cnn)
        {
            try {
                cnn.Close();
            }
            catch (Exception) {
                throw;
            }
            return true;
        }

        public DataTable GetDataTable(string sql)
        {
            SqlConnection cnn = new SqlConnection(mCS);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataTable dt = new DataTable();
            
            try {
                cnn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception) {
                throw;
            }
            finally {
                cnn.Close();
            }
            return dt;
        }

        public DataTable GetDataTable(SqlConnection cnn, string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            DataTable dt = new DataTable();
            
            try {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception) {
                throw;
            }
            return dt;
        }

        public DataTable GetDataTable(SqlCommand cmd, string sql)
        {
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            
            try {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception) {
                throw;
            }
            return dt;
        }

        public bool UpdateDataTable(string sql)
        {
            SqlConnection cnn = new SqlConnection(mCS);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            int result;

            try {
                cnn.Open();
                result = cmd.ExecuteNonQuery();
                
                if (result < 0) {
                    return false;
                }
                else {
                    return true;
                }
            }
            catch (Exception) {
                throw;
            }
            finally {
                cnn.Close();
            }
        }
    }
}

//ACCESS DATABASE:
namespace DBControl
{
    public class DBKlassement
    {
        public static string mCS = System.Configuration.ConfigurationManager.ConnectionStrings["Vanlommel.Properties.Settings.ScanVettenDbConnectionString"].ConnectionString;

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

        public DataTable GetDataTable(string sql)
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

        public bool UpdateDataTable(string sql)
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
}
