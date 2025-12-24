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
    public class DAOwnerDetails : IOwnerDetails
    {
        private readonly string ProcedureName = "OwnerManagement";

        public Response AddOwnerDetails(OwnerDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Owner added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllOwnerDetails(OwnerDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<OwnerDetailsModel> OwnerDetailsList = new List<OwnerDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        OwnerDetailsModel Owner = new OwnerDetailsModel
                        {

                            OwnerID = row["tod_owner_id"].ToString(),
                            UserID = row["tod_user_id"].ToString(),
                            OwnerName = row["tod_owner_name"].ToString(),
                            PhoneNo = row["tod_phone_no"].ToString(),
                            Status = row["tod_status"].ToString(),
                            CreateDate = row["tod_create_date"].ToString(),
                            CreatedBy = row["tod_created_by"].ToString(),
                            UpdatedDate = row["tod_updated_date"].ToString(),
                            UpdatedBy = row["tod_updated_by"].ToString(),

                        };
                        OwnerDetailsList.Add(Owner);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = OwnerDetailsList;
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

        public Response GetOwnerDetailsByOwnerID(OwnerDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<OwnerDetailsModel> OwnerDetailsList = new List<OwnerDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        OwnerDetailsModel Owner = new OwnerDetailsModel
                        {
                            OwnerID = row["tod_owner_id"].ToString(),
                            UserID = row["tod_user_id"].ToString(),
                            OwnerName = row["tod_owner_name"].ToString(),
                            PhoneNo = row["tod_phone_no"].ToString(),
                            Status = row["tod_status"].ToString(),
                            CreateDate = row["tod_create_date"].ToString(),
                            CreatedBy = row["tod_created_by"].ToString(),
                            UpdatedDate = row["tod_updated_date"].ToString(),
                            UpdatedBy = row["tod_updated_by"].ToString(),

                        };
                        OwnerDetailsList.Add(Owner);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = OwnerDetailsList;
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

        public Response PutOwnerDetails(OwnerDetailsRequestApi requestAPI)
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

        public Response UpdateOwnerStatus(OwnerDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Owner status updated successfully!";
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

  