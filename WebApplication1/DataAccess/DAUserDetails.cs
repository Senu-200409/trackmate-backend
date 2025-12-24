using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TrackMateBackend.Database_Layer;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;
using TrackMateBackend.Static;

namespace TrackMateBackend.DataAccess
{
    public class DAUserDetails : IUserDetails
    {
        private readonly string ProcedureName = "UserManagement";

        public Response RegisterUser(UserDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "User registered successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        public Response LoginUser(UserDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.ResultSet = res.ResultDataTable;   // return user details
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        public Response GetAllUsers(UserDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<UserDetailsModel> userList = new List<UserDetailsModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        UserDetailsModel user = new UserDetailsModel
                        {
                            UserID = row["tud_user_id"].ToString(),
                            Phone = row["tud_phone"].ToString(),
                            UserType = row["tud_user_type"].ToString(),
                            Status = row["tud_status"].ToString(),
                            CreateDate = row["tud_create_date"].ToString(),
                            CreatedBy = row["tud_created_by"].ToString(),
                            UpdatedDate = row["tud_updated_date"].ToString(),
                            UpdatedBy = row["tud_updated_by"].ToString()
                        };

                        userList.Add(user);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = userList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        public Response GetUserByUserID(UserDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "4";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<UserDetailsModel> userList = new List<UserDetailsModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        UserDetailsModel user = new UserDetailsModel
                        {
                            UserID = row["tud_user_id"].ToString(),
                            Phone = row["tud_phone"].ToString(),
                            UserType = row["tud_user_type"].ToString(),
                            Status = row["tud_status"].ToString(),
                            CreateDate = row["tud_create_date"].ToString(),
                            CreatedBy = row["tud_created_by"].ToString(),
                            UpdatedDate = row["tud_updated_date"].ToString(),
                            UpdatedBy = row["tud_updated_by"].ToString()
                        };

                        userList.Add(user);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = userList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }

        public Response UpdateUser(UserDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                result.StatusCode = res.ResultStatusCode == "1" ? 200 : 400;
                result.Result = res.Result;
            }

            return result;
        }

        public Response UpdateUserStatus(UserDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "6";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "User status updated successfully!";
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }

            return result;
        }
    }
}
   