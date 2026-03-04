using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using TrackMateBackend.Models;


namespace TrackMateBackend.Database_Layer
{
    internal class DBconnect : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DBconnect()
        {
            //_connectionString = string.Format("Data Source=ito-test020; " +
            //  "Initial Catalog=NOC-OPS;" +
            //  "User id=sa;" +
            //  "Password=admin@123; MultipleActiveResultSets=true;Max Pool Size=600;");


            _connectionString = string.Format("Data Source=SENU_RY; " +
              "Initial Catalog=trackmate_db;" +
              "Integrated Security=True; " +
              "MultipleActiveResultSets=true;" +
              "Max Pool Size=600;");

            //_connectionString = string.Format("Data Source=ALL-SER-LAP01\\DTSSQLSERVER; " +
            //        "Initial Catalog=trackmate;" +
            //        "User id=sa;" +
            //        "Password=DSadmin@123; MultipleActiveResultSets=true;Max Pool Size=600;");



        }

        public SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public SqlDataReader ReadTable(string query)
        {
            SqlConnection connection = GetOpenConnection();
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //        public bool AddEditDel(string query)
        //        {
        //            using (SqlConnection connection = GetOpenConnection())
        //            {
        //                SqlCommand command = new SqlCommand(query, connection);
        //                int affectedRows = command.ExecuteNonQuery();
        //                return affectedRows > 0;
        //            }
        //        }

        //        public void Dispose()
        //        {
        //            if (_connection != null)
        //            {
        //                _connection.Dispose();
        //                _connection = null;
        //            }
        //        }

        //internal void ExecuteQuery(string query)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        internal bool AddEditDel(object query)
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }
        //}

        public ProcedureDBModel ProcedureRead(RequestAPI requestAPI, string procedureName)
        {
            ProcedureDBModel result = new ProcedureDBModel();
            using (SqlConnection connection = GetOpenConnection())
            using (SqlCommand cmd = new SqlCommand(procedureName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Add output parameters
                SqlParameter statusCodeParam = new SqlParameter("@ResultStatusCode", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(statusCodeParam);

                SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.VarChar, -1)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultParam);

                SqlParameter exceptionParam = new SqlParameter("@ExceptionMessage", SqlDbType.VarChar, -1)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(exceptionParam);

                SqlParameter UIDParam = new SqlParameter("@UID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(UIDParam);

                SqlParameter SIDParam = new SqlParameter("@SID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(SIDParam);

                //SqlParameter InsertedSchoolIDParam = new SqlParameter("@InsertedSchoolID", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(InsertedSchoolIDParam);

                // Map input properties
                Type type = requestAPI.GetType();
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    string paramName = "@" + property.Name;
                    object value = property.GetValue(requestAPI) ?? DBNull.Value;

                    SqlParameter param = new SqlParameter(paramName, SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = value
                    };
                    cmd.Parameters.Add(param);
                }

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        result.ResultDataTable = dt;
                    }

                    // Get output parameter values after execution
                    result.ResultStatusCode = statusCodeParam.Value != DBNull.Value ?
                        statusCodeParam.Value.ToString() : "1";
                    result.Result = resultParam.Value != DBNull.Value ?
                        resultParam.Value.ToString() : "Success";
                    result.ExceptionMessage = exceptionParam.Value != DBNull.Value ?
                        exceptionParam.Value.ToString() : null;
                    result.UID = UIDParam.Value != DBNull.Value ?
                        Convert.ToInt32(UIDParam.Value) : (int?)null;
                    result.SID = SIDParam.Value != DBNull.Value ?
                        Convert.ToInt32(SIDParam.Value) : (int?)null;
                    //result.UID = InsertedSchoolIDParam.Value != DBNull.Value ?
                    //    Convert.ToInt32(InsertedSchoolIDParam.Value) : (int?)null;
                }
                catch (Exception ex)
                {
                    result.ResultStatusCode = "-1";
                    result.ExceptionMessage = ex.Message;
                }

                return result;
            }
        }

        //public bool AddEditDel(string AddEditDelStr)
        //{
        //    SqlConnection connection = GetOpenConnection();
        //    var command = new SqlCommand(AddEditDelStr, connection);
        //    int affectedRows = command.ExecuteNonQuery();
        //    connection.Close(); // Close the connection after executing the query
        //    return affectedRows > 0;
        //}
        public bool AddEditDel(string query)
        {
            using (var connection = GetOpenConnection())
            using (var command = new SqlCommand(query, connection))
            {
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows > 0;
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        internal void ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}

//public ProcedureDBModel ProcedureRead(RequestAPI requestAPI, string procedureName)
//        {
//            var result = new ProcedureDBModel();

//            using (var connection = GetOpenConnection())
//            using (var cmd = new SqlCommand(procedureName, connection))
//            {
//                cmd.CommandType = CommandType.StoredProcedure;

//                // Output parameters
//                var statusCodeParam = cmd.Parameters.Add("@ResultStatusCode", SqlDbType.Int);
//                statusCodeParam.Direction = ParameterDirection.Output;

//                var resultParam = cmd.Parameters.Add("@Result", SqlDbType.VarChar, -1);
//                resultParam.Direction = ParameterDirection.Output;

//                var exceptionParam = cmd.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar, -1);
//                exceptionParam.Direction = ParameterDirection.Output;

//                var UIDParam = cmd.Parameters.Add("@UID", SqlDbType.Int);
//                UIDParam.Direction = ParameterDirection.Output;


//                // Input parameters
//                foreach (var property in requestAPI.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
//                {
//                    string paramName = "@" + property.Name;
//                    object value = property.GetValue(requestAPI) ?? DBNull.Value;

//                    cmd.Parameters.AddWithValue(paramName, value);
//                }

//                try
//                {
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        var dt = new DataTable();
//                        dt.Load(reader);
//                        result.ResultDataTable = dt;
//                    }

//                    result.ResultStatusCode = statusCodeParam.Value?.ToString() ?? "1";
//                    result.Result = resultParam.Value?.ToString() ?? "Success";
//                    result.ExceptionMessage = exceptionParam.Value as string;
//                    //result.UID = UIDParam.Value != DBNull.Value
//                    //        ? UIDParam.Value.ToString()
//                    //        : null;
//                    result.UID = UIDParam.Value != DBNull.Value ?
//Convert.ToInt32(UIDParam.Value) : (int?)null;
//                }
//                catch (Exception ex)
//                {
//                    result.ResultStatusCode = "-1";
//                    result.ExceptionMessage = ex.Message;
//                }
//            }

//            return result;
//        }

//        public bool AddEditDel(string query)
//        {
//            using (var connection = GetOpenConnection())
//            using (var command = new SqlCommand(query, connection))
//            {
//                int affectedRows = command.ExecuteNonQuery();
//                return affectedRows > 0;
//            }
//        }

//        public void Dispose()
//        {
//            if (_connection != null)
//            {
//                _connection.Dispose();
//                _connection = null;
//            }
//        }
//    }
//}