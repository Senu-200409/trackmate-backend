//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using TrackMateBackend.Database_Layer;
//using TrackMateBackend.Interfaces;
//using TrackMateBackend.Models;
//using TrackMateBackend.Models.RequestApiModels;
//using TrackMateBackend.Static;

//namespace TrackMateBackend.DataAccess
//{
//    public class DARoutesDetails : IRoutesDetails
//    {
//        private readonly string ProcedureName = "RouteManagement";

//        public Response AddRoutesDetails(RoutesDetailsRequestApi requestAPI)
//        {
//            Response result = new Response();
//            requestAPI.ActionType = "1";

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

//                if (res.ResultStatusCode == "1")
//                {
//                    result.StatusCode = 200;
//                    result.Result = "Route added successfully!";
//                }
//                else
//                {
//                    result.StatusCode = 500;
//                    result.Result = res.ExceptionMessage;
//                }
//            }
//            return result;
//        }

//        public Response GetAllRoutesDetails(RoutesDetailsRequestApi requestAPI)
//        {
//            Response result = new Response();
//            requestAPI.ActionType = "2";

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
//                if (res.ResultStatusCode == "1")
//                {
//                    List<RoutesDetailsModel> RoutesDetailsList = new List<RoutesDetailsModel>();
//                    foreach (DataRow row in res.ResultDataTable.Rows)
//                    {
//                        RoutesDetailsModel Route = new RoutesDetailsModel
//                        {

//                            BarcodeScript = row["trd_barcode_script"].ToString(),
//                            RfidID = row["trd_rfid_id"].ToString(),
//                            DeviceID = row["trd_device_id"].ToString(),
//                            NumberPlate = row["trd_number_plate"].ToString(),
//                            RouteName = row["trd_route_name"].ToString(),
//                            Time = row["trd_time"].ToString(),
//                            Status = row["trd_status"].ToString(),
//                            CreateDate = row["trd_create_date"].ToString(),
//                            CreatedBy = row["trd_created_by"].ToString(),
//                            UpdatedDate = row["trd_updated_date"].ToString(),
//                            UpdatedBy = row["trd_updated_by"].ToString(),

//                        };
//                        RoutesDetailsList.Add(Route);
//                    }

//                    result.StatusCode = 200;
//                    result.ResultSet = RoutesDetailsList;
//                }
//                else
//                {
//                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
//                    result.StatusCode = 500;
//                    result.Result = res.ExceptionMessage;
//                }

//                return result;
//            }
//        }

//        public Response GetRoutesDetailsByBarcodeScript(RoutesDetailsRequestApi requestAPI)
//        {

//            Response result = new Response();
//            requestAPI.ActionType = "3";

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
//                if (res.ResultStatusCode == "1")
//                {
//                    List<RoutesDetailsModel> RoutesDetailsList = new List<RoutesDetailsModel>();
//                    foreach (DataRow row in res.ResultDataTable.Rows)
//                    {
//                        RoutesDetailsModel Route = new RoutesDetailsModel
//                        {
//                            BarcodeScript = row["trd_barcode_script"].ToString(),
//                            RfidID = row["trd_rfid_id"].ToString(),
//                            DeviceID = row["trd_device_id"].ToString(),
//                            NumberPlate = row["trd_number_plate"].ToString(),
//                            RouteName = row["trd_route_name"].ToString(),
//                            Time = row["trd_time"].ToString(),
//                            Status = row["trd_status"].ToString(),
//                            CreateDate = row["trd_create_date"].ToString(),
//                            CreatedBy = row["trd_created_by"].ToString(),
//                            UpdatedDate = row["trd_updated_date"].ToString(),
//                            UpdatedBy = row["trd_updated_by"].ToString(),

//                        };
//                        RoutesDetailsList.Add(Route);
//                    }
//                    result.StatusCode = 200;
//                    result.ResultSet = RoutesDetailsList;
//                }
//                else
//                {
//                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
//                    result.StatusCode = 500;
//                    result.Result = res.ExceptionMessage;
//                }
//                return result;
//            }
//        }

//        public Response PutRoutesDetails(RoutesDetailsRequestApi requestAPI)
//        {
//            Response result = new Response();
//            requestAPI.ActionType = "4"; // Update

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

//                result.StatusCode = res.ResultStatusCode == "1" ? 200 : 400;
//                result.Result = res.Result;
//            }

//            return result;
//        }

//        public Response UpdateRoutesStatus(RoutesDetailsRequestApi requestAPI)
//        {
//            Response result = new Response();
//            requestAPI.ActionType = "5"; // Status Update

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

//                if (res.ResultStatusCode == "1")
//                {
//                    result.StatusCode = 200;
//                    result.Result = "Route status updated successfully!";
//                }
//                else
//                {
//                    LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
//                    result.StatusCode = 500;
//                    result.Result = res.ExceptionMessage;
//                }
//            }

//            return result;
//        }
//    }
//}