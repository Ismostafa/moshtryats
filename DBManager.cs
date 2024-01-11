using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshtarayat
{
    public class DBManager
    {
        static string DB_Connection_String = @"Data Source=STW\SQLEXPRESS;Initial Catalog=Moshtarayat;Integrated Security=True";
        SqlConnection myConnection;

        public DBManager()
        {
            myConnection = new SqlConnection(DB_Connection_String);
            try
            {
                myConnection.Open();
                Console.WriteLine("The DB connection is opened successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("The DB connection is failed");
                Console.WriteLine(e.ToString());
            }
        }

        public int ExecuteNonQuery(string storedProcedureName, Dictionary<string, object> parameters)
        {
            try
            {
                
                SqlCommand myCommand = new SqlCommand(storedProcedureName, myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> Param in parameters)
                {
                    myCommand.Parameters.Add(new SqlParameter(Param.Key, Param.Value));
                }
               
                return myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public DataTable ExecuteReader(string storedProcedureName, Dictionary<string, object> parameters)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(storedProcedureName, myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> Param in parameters)
                    {
                        myCommand.Parameters.Add(new SqlParameter(Param.Key, Param.Value));
                    }
                }

                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                else
                {
                    reader.Close();
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public object ExecuteScalar(string storedProcedureName, Dictionary<string, object> parameters)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(storedProcedureName, myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> Param in parameters)
                    {
                        myCommand.Parameters.Add(new SqlParameter(Param.Key, Param.Value));
                    }
                }

                return myCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void CloseConnection()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int ExecuteNonQuery1(string storedProcedureName, Dictionary<string, object> parameters,string output)
        {
            try
            {

                SqlCommand myCommand = new SqlCommand(storedProcedureName, myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> Param in parameters)
                {
                    myCommand.Parameters.Add(new SqlParameter(Param.Key, Param.Value));

                }
                
                SqlParameter RuturnValue = new SqlParameter(output, SqlDbType.Int);
                RuturnValue.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(RuturnValue);
                //  myCommand.Parameters.Add("@retValue", System.Data.SqlDbType.VarChar).Direction = System.Data.ParameterDirection.ReturnValue;
                 myCommand.ExecuteNonQuery();
                return (int)myCommand.Parameters[output].Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0 ;
            }
        }
    }
}

