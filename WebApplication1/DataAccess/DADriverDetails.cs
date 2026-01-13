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
    public class DADriverDetails : IDriverDetails
    {
        private readonly string ProcedureName = "DriverManagement";

        public Response AddDriverDetails(DriverDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Driver added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllDriverDetails(DriverDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<DriverDetailsModel> DriverDetailsList = new List<DriverDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        DriverDetailsModel Driver = new DriverDetailsModel
                        {

                            DriverID = row["tdd_driver_id"].ToString(),
                            UserID = row["tdd_user_id"].ToString(),
                           // SchoolID = row["tdd_school_id"].ToString(),
                            Name = row["tdd_name"].ToString(),
                            PhoneNo = row["tdd_phone_no"].ToString(),
                            LicenseNo = row["tdd_license_no"].ToString(),
                            LicenseType = row["tdd_license_type"].ToString(),
                            Status = row["tdd_status"].ToString(),
                            CreateDate = row["tdd_create_date"].ToString(),
                            CreatedBy = row["tdd_created_by"].ToString(),
                            UpdatedDate = row["tdd_updated_date"].ToString(),
                            UpdatedBy = row["tdd_updated_by"].ToString(),

                        };
                        DriverDetailsList.Add(Driver);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = DriverDetailsList;
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

        public Response GetDriverDetailsByDriverID(DriverDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<DriverDetailsModel> DriverDetailsList = new List<DriverDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        DriverDetailsModel Driver = new DriverDetailsModel
                        {
                            DriverID = row["tdd_driver_id"].ToString(),
                            UserID = row["tdd_user_id"].ToString(),
                           // SchoolID = row["tdd_school_id"].ToString(),
                            Name = row["tdd_name"].ToString(),
                            PhoneNo = row["tdd_phone_no"].ToString(),
                            LicenseNo = row["tdd_license_no"].ToString(),
                            LicenseType = row["tdd_license_type"].ToString(),
                            Status = row["tdd_status"].ToString(),
                            CreateDate = row["tdd_create_date"].ToString(),
                            CreatedBy = row["tdd_created_by"].ToString(),
                            UpdatedDate = row["tdd_updated_date"].ToString(),
                            UpdatedBy = row["tdd_updated_by"].ToString(),

                        };
                        DriverDetailsList.Add(Driver);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = DriverDetailsList;
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

        public Response PutDriverDetails(DriverDetailsRequestApi requestAPI)
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

        //public Response UpdateDriverStatus(DriverDetailsRequestApi requestAPI)
        //{
        //    Response result = new Response();
        //    requestAPI.ActionType = "5"; // Status Update

        //    using (var dbConnect = new DBconnect())
        //    {
        //        ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

        //        if (res.ResultStatusCode == "1")
        //        {
        //            result.StatusCode = 200;
        //            result.Result = "Driver status updated successfully!";
        //        }
        //        else
        //        {
        //            LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //            result.StatusCode = 500;
        //            result.Result = res.ExceptionMessage;
        //        }
        //    }

        //    return result;
        //}
    }
}

