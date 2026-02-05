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

                if (res.ResultStatusCode == "1" && res.UID.HasValue)
                {
                    result.StatusCode = 200;
                    result.Result = "User registered successfully!";
                    result.ResultSet = new
                    {
                        UID = res.UID.Value
                    };
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage ?? "User registered but UserID not returned from server";
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
                            UserName = row["tud_user_name"].ToString(),
                            ProfileImage = row["tud_profile_image"].ToString(),
                            Otp = row["tud_otp"].ToString(),
                            OtpExpiry = row["tud_otp_expiry"].ToString(),
                            lastLogin = row["tud_last_login"].ToString(),
                            Status = row["tud_status"].ToString(),
                            CreatedDate = row["tud_created_date"].ToString(),
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
                            UserName = row["tud_user_name"].ToString(),
                            ProfileImage = row["tud_profile_image"].ToString(),
                            Otp = row["tud_otp"].ToString(),
                            OtpExpiry = row["tud_otp_expiry"].ToString(),
                            lastLogin = row["tud_last_login"].ToString(),
                            Status = row["tud_status"].ToString(),
                            CreatedDate = row["tud_created_date"].ToString(),
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

        public Response SendOtp(UserDetailsRequestApi requestAPI)
        {
            Response response = new Response();
            requestAPI.ActionType = "2";

            using (var db = new DBconnect())
            {
                var res = db.ProcedureRead(requestAPI, ProcedureName);

                // All string comparisons
                if (res.ResultStatusCode != "1" || res.ResultDataTable == null || res.ResultDataTable.Rows.Count == 0)
                {
                    response.StatusCode = 404;
                    response.Result = "User not found or inactive.";
                    return response;
                }
            }

            string otp = new Random().Next(100000, 999999).ToString();
            string url = $"https://esystems.cdl.lk/Backend/SMSGateway/api/SMS/DTSSendMessage?mobileNo={requestAPI.Phone}&message=Your OTP is {otp}";

            using (var client = new System.Net.Http.HttpClient())
            {
                client.GetAsync(url).Wait();
            }

            response.StatusCode = 200;
            response.Result = "OTP sent successfully.";
            response.ResultSet = otp;

            return response;
        }


    }
}

//using System;
//using TrackMateBackend.Database_Layer;
//using TrackMateBackend.Interfaces;
//using TrackMateBackend.Models;
//using TrackMateBackend.Models.RequestApiModels;

//namespace TrackMateBackend.DataAccess
//{
//    public class DAUserDetails : IUserDetails
//    {
//        private readonly string ProcedureName = "UserManagement";

//        public Response RegisterUser(UserDetailsRequestAPI request)
//        {
//            request.ActionType = "1";
//            return Execute(request, "User registered successfully.");
//        }

//        public Response SendOtp(UserDetailsRequestAPI request)
//        {
//            Response response = new Response();
//            request.ActionType = "2";

//            using (var db = new DBconnect())
//            {
//                var res = db.ProcedureRead(request, ProcedureName);

//                // All string comparisons
//                if (res.ResultStatusCode != "1" || res.ResultDataTable == null || res.ResultDataTable.Rows.Count == 0)
//                {
//                    response.StatusCode = 404;
//                    response.Result = "User not found or inactive.";
//                    return response;
//                }
//            }

//            string otp = new Random().Next(100000, 999999).ToString();
//            string url = $"https://esystems.cdl.lk/Backend/SMSGateway/api/SMS/DTSSendMessage?mobileNo={request.Phone}&message=Your OTP is {otp}";

//            using (var client = new System.Net.Http.HttpClient())
//            {
//                client.GetAsync(url).Wait();
//            }

//            response.StatusCode = 200;
//            response.Result = "OTP sent successfully.";
//            response.ResultSet = otp;

//            return response;
//        }

//        public Response GetUserById(UserDetailsRequestAPI request)
//        {
//            request.ActionType = "4";
//            return ExecuteWithData(request);
//        }

//        public Response GetAllUsers(UserDetailsRequestAPI request)
//        {
//            request.ActionType = "3";
//            return ExecuteWithData(request);
//        }

//        public Response UpdateUser(UserDetailsRequestAPI request)
//        {
//            request.ActionType = "5";
//            return Execute(request, "User updated successfully.");
//        }

//        public Response DeleteUser(UserDetailsRequestAPI request)
//        {
//            request.ActionType = "6";
//            request.Status = "I";
//            return Execute(request, "User deleted successfully.");
//        }

//        private Response Execute(UserDetailsRequestAPI request, string successMessage)
//        {
//            Response response = new Response();

//            try
//            {
//                using (var db = new DBconnect())
//                {
//                    var res = db.ProcedureRead(request, ProcedureName);

//                    if (res.ResultStatusCode == "1") // ✅ string comparison
//                    {
//                        response.StatusCode = 200;
//                        response.Result = successMessage;
//                    }
//                    else
//                    {
//                        response.StatusCode = 500;
//                        response.Result = res.ExceptionMessage;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                response.StatusCode = 500;
//                response.Result = ex.Message;
//            }

//            return response;
//        }

//        private Response ExecuteWithData(UserDetailsRequestAPI request)
//        {
//            Response response = new Response();

//            try
//            {
//                using (var db = new DBconnect())
//                {
//                    var res = db.ProcedureRead(request, ProcedureName);

//                    if (res.ResultStatusCode == "1" && res.ResultDataTable != null) // ✅ string comparison
//                    {
//                        response.StatusCode = 200;
//                        response.Result = "Data fetched successfully.";
//                        response.ResultSet = res.ResultDataTable;
//                    }
//                    else
//                    {
//                        response.StatusCode = 404;
//                        response.Result = "No data found.";
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                response.StatusCode = 500;
//                response.Result = ex.Message;
//            }

//            return response;
//        }
//    }
//}
