using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ATTravelOffer
{
    public class DataAccessObject
    {

        public SqlConnection sqlConnection = null;
        DataSet ds = null;
        string DatabaseConnection = "";

        public DataAccessObject()
        {
            DatabaseConnection = ConfigurationManager.AppSettings["dbConnection"];
            //DatabaseConnection = ConfigurationManager.AppSettings["dbTestConnection"];
        }

        public void OpenConnection()
        {
            try
            {
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection();
                    sqlConnection.ConnectionString = DatabaseConnection;
                    sqlConnection.Open();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable OpenDataTable(string spName, SqlParameter[] spParams)
        {
            try
            {
                OpenConnection();

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandText = spName;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 0;

                    if (spParams != null)
                        sqlCommand.Parameters.AddRange(spParams);

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }

                    return ds.Tables[0];
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

        }
    }
}
