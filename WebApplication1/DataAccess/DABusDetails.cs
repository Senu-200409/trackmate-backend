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
    public class DABusDetails : IBusDetails
    {
        private readonly string ProcedureName = "BusManagement";

        public Response AddBusDetails(BusDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1"; 

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Bus added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllBusDetails(BusDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<BusDetailsModel> BusDetailsList = new List<BusDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        BusDetailsModel Bus = new BusDetailsModel
                        {

                            NumberPlate = row["tbd_number_plate"].ToString(),
                            DriverID = row["tbd_driver_id"].ToString(),
                            SchoolID = row["tbd_school_id"].ToString(),
                            Status = row["tbd_status"].ToString(),
                            CreateDate = row["tbd_create_date"].ToString(),
                            CreatedBy = row["tbd_created_by"].ToString(),
                            UpdatedDate = row["tbd_updated_date"].ToString(),
                            UpdatedBy = row["tbd_updated_by"].ToString(),

                        };
                        BusDetailsList.Add(Bus);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = BusDetailsList;
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

        public Response GetBusDetailsByNumberplate(BusDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<BusDetailsModel> BusDetailsList = new List<BusDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        BusDetailsModel Bus = new BusDetailsModel
                        {
                            NumberPlate = row["tbd_number_plate"].ToString(),
                            DriverID = row["tbd_driver_id"].ToString(),
                            SchoolID = row["tbd_school_id"].ToString(),
                            Status = row["tbd_status"].ToString(),
                            CreateDate = row["tbd_create_date"].ToString(),
                            CreatedBy = row["tbd_created_by"].ToString(),
                            UpdatedDate = row["tbd_updated_date"].ToString(),
                            UpdatedBy = row["tbd_updated_by"].ToString(),

                        };
                        BusDetailsList.Add(Bus);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = BusDetailsList;
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

        public Response PutBusDetails(BusDetailsRequestApi requestAPI)
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

        public Response UpdateBusStatus(BusDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Bus status updated successfully!";
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
