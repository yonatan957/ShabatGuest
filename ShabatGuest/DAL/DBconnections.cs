using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatGuest.DAL
{
    internal class DBconnections
    {
        private string _connectionString { get; init; }

        public DBconnections(string conn)
        {
            if (string.IsNullOrEmpty(conn))
                throw new ArgumentNullException(nameof(conn));
            _connectionString = conn;
        }
        private void CheckConnection()
        {
            // הפעלת שאילתא פשוטה כדי לבדוק אם החיבור עובד
            DataTable result = ExecuteQuery("SELECT 1+1 AS test", null!);
            if (Convert.ToInt32(result.Rows[0][0]) != 2)
                throw new Exception("Failed to connect to the database.");
        }
        public int ExecuteNoneQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("An error occurred:" + ex.Message);
                        return -1;
                    }
                }
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("An error occurred:" + ex.Message);
                    }
                }
            }
            return dt;
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        //מכניס ערך בודד מהתוצאה
                        return cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"General Error: {ex.Message}");
                    }

                    return null;
                }
            }
        }

        private string SqlEscape(string input)
        {
            return input.Replace("'", "''");
        }
        public void CheckConnectionToDefaultDB(string dbName)
        {
            CheckConnection();
            //בודק האם קיים דאטאבייס בשם זה
            string query = $"SELECT db_id('{SqlEscape(dbName)}');";

            DataTable result = ExecuteQuery(query, null!);
            if (result == null || result.Rows.Count == 0 || result.Rows[0][0] == DBNull.Value)
                throw new Exception($"Database {dbName} is not defined.");
        }
    }
}
