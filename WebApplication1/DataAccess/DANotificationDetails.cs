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
    public class DANotificationDetails : INotificationDetails
    {
        private readonly string ProcedureName = "NotificationManagement";

        public Response AddNotificationDetails(NotificationDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Notification added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllNotificationDetails(NotificationDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<NotificationDetailsModel> NotificationDetailsList = new List<NotificationDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        NotificationDetailsModel Notification = new NotificationDetailsModel
                        {

                            NotificationID = row["tnd_notification_id"].ToString(),
                            SentDate = row["tnd_sent_date"].ToString(),
                            ParentID = row["tnd_parent_id"].ToString(),
                            OwnerID = row["tnd_owner_id"].ToString(),
                            Status = row["tnd_status"].ToString(),
                            CreateDate = row["tnd_create_date"].ToString(),
                            CreatedBy = row["tnd_created_by"].ToString(),
                            UpdatedDate = row["tnd_updated_date"].ToString(),
                            UpdatedBy = row["tnd_updated_by"].ToString(),

                        };
                        NotificationDetailsList.Add(Notification);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = NotificationDetailsList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }

                return result;
            }
        }

        public Response GetNotificationDetailsByNotificationID(NotificationDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<NotificationDetailsModel> NotificationDetailsList = new List<NotificationDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        NotificationDetailsModel Notification = new NotificationDetailsModel
                        {
                            NotificationID = row["tnd_notification_id"].ToString(),
                            SentDate = row["tnd_sent_date"].ToString(),
                            ParentID = row["tnd_parent_id"].ToString(),
                            OwnerID = row["tnd_owner_id"].ToString(),
                            Status = row["tnd_status"].ToString(),
                            CreateDate = row["tnd_create_date"].ToString(),
                            CreatedBy = row["tnd_created_by"].ToString(),
                            UpdatedDate = row["tnd_updated_date"].ToString(),
                            UpdatedBy = row["tnd_updated_by"].ToString(),

                        };
                        NotificationDetailsList.Add(Notification);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = NotificationDetailsList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
                return result;
            }
        }

        public Response PutNotificationDetails(NotificationDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "4"; // Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                result.StatusCode = res.ResultStatusCode == "1" ? 200 : 400;
                result.Result = res.Result;
            }

            return result;
        }

        public Response UpdateNotificationStatus(NotificationDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Notification status updated successfully!";
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
