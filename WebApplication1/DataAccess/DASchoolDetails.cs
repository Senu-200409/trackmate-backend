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
    public class DASchoolDetails : ISchoolDetails
    {
        private readonly string ProcedureName = "SchoolManagement";

        public Response AddSchoolDetails(SchoolDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "School added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllSchoolDetails(SchoolDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<SchoolDetailsModel> SchoolDetailsList = new List<SchoolDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        SchoolDetailsModel School = new SchoolDetailsModel
                        {

                            SchoolID = row["tsd_school_id"].ToString(),
                            SchoolName = row["tsd_school_name"].ToString(),
                            City = row["tsd_city"].ToString(),
                            Town = row["tsd_town"].ToString(),
                            Address = row["tsd_address"].ToString(),
                            Status = row["tsd_status"].ToString(),
                            CreateDate = row["tsd_create_date"].ToString(),
                            CreatedBy = row["tsd_created_by"].ToString(),
                            UpdatedDate = row["tsd_updated_date"].ToString(),
                            UpdatedBy = row["tsd_updated_by"].ToString(),

                        };
                        SchoolDetailsList.Add(School);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = SchoolDetailsList;
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

        public Response GetSchoolDetailsBySchoolID(SchoolDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<SchoolDetailsModel> SchoolDetailsList = new List<SchoolDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        SchoolDetailsModel School = new SchoolDetailsModel
                        {
                            SchoolID = row["tsd_school_id"].ToString(),
                            SchoolName = row["tsd_school_name"].ToString(),
                            City = row["tsd_city"].ToString(),
                            Town = row["tsd_town"].ToString(),
                            Address = row["tsd_address"].ToString(),
                            Status = row["tsd_status"].ToString(),
                            CreateDate = row["tsd_create_date"].ToString(),
                            CreatedBy = row["tsd_created_by"].ToString(),
                            UpdatedDate = row["tsd_updated_date"].ToString(),
                            UpdatedBy = row["tsd_updated_by"].ToString(),

                        };
                        SchoolDetailsList.Add(School);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = SchoolDetailsList;
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

        public Response PutSchoolDetails(SchoolDetailsRequestApi requestAPI)
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

        public Response UpdateSchoolStatus(SchoolDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "School status updated successfully!";
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