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
    public class DAParentDetails : IParentDetails
    {
        private readonly string ProcedureName = "ParentManagement";

        public Response AddParentDetails(ParentDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Parent added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllParentDetails(ParentDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<ParentDetailsModel> ParentDetailsList = new List<ParentDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        ParentDetailsModel Parent = new ParentDetailsModel
                        {

                            ParentID = row["tpd_parent_id"].ToString(),
                            Name = row["tpd_name"].ToString(),
                            UserID = row["tpd_user_id"].ToString(),
                           // SchoolID = row["tpd_school_id"].ToString(),
                            Address = row["tpd_address"].ToString(),
                            ContactNo = row["tpd_contact_no"].ToString(),
                            ContactNo2 = row["tpd_contact_no2"].ToString(),
                            Status = row["tpd_status"].ToString(),
                            CreateDate = row["tpd_create_date"].ToString(),
                            CreatedBy = row["tpd_created_by"].ToString(),
                            UpdatedDate = row["tpd_updated_date"].ToString(),
                            UpdatedBy = row["tpd_updated_by"].ToString(),

                        };
                        ParentDetailsList.Add(Parent);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = ParentDetailsList;
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

        public Response GetParentDetailsByParentID(ParentDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<ParentDetailsModel> ParentDetailsList = new List<ParentDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        ParentDetailsModel Parent = new ParentDetailsModel
                        {
                            ParentID = row["tpd_parent_id"].ToString(),
                            Name = row["tpd_name"].ToString(),
                            UserID = row["tpd_user_id"].ToString(),
                           // SchoolID = row["tpd_school_id"].ToString(),
                            Address = row["tpd_address"].ToString(),
                            ContactNo = row["tpd_contact_no"].ToString(),
                            ContactNo2 = row["tpd_contact_no2"].ToString(),
                            Status = row["tpd_status"].ToString(),
                            CreateDate = row["tpd_create_date"].ToString(),
                            CreatedBy = row["tpd_created_by"].ToString(),
                            UpdatedDate = row["tpd_updated_date"].ToString(),
                            UpdatedBy = row["tpd_updated_by"].ToString(),

                        };
                        ParentDetailsList.Add(Parent);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = ParentDetailsList;
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

        public Response PutParentDetails(ParentDetailsRequestApi requestAPI)
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

        public Response UpdateParentStatus(ParentDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Parent status updated successfully!";
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