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
    public class DADeviceDetails : IDeviceDetails
    {
        private readonly string ProcedureName = "DeviceManagement";

        public Response AddDeviceDetails(DeviceDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Device added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllDeviceDetails(DeviceDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<DeviceDetailsModel> DeviceDetailsList = new List<DeviceDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        DeviceDetailsModel Device = new DeviceDetailsModel
                        {

                            DeviceID = row["ted_device_id"].ToString(),
                            DeviceName = row["ted_device_name"].ToString(),
                            NumberPlate = row["ted_number_plate"].ToString(),
                            Status = row["ted_status"].ToString(),
                            CreateDate = row["ted_create_date"].ToString(),
                            CreatedBy = row["ted_created_by"].ToString(),
                            UpdatedDate = row["ted_updated_date"].ToString(),
                            UpdatedBy = row["ted_updated_by"].ToString(),

                        };
                        DeviceDetailsList.Add(Device);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = DeviceDetailsList;
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

        public Response GetDeviceDetailsByDeviceID(DeviceDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<DeviceDetailsModel> DeviceDetailsList = new List<DeviceDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        DeviceDetailsModel Device = new DeviceDetailsModel
                        {
                            DeviceID = row["ted_device_id"].ToString(),
                            DeviceName = row["ted_device_name"].ToString(),
                            NumberPlate = row["ted_number_plate"].ToString(),
                            Status = row["ted_status"].ToString(),
                            CreateDate = row["ted_create_date"].ToString(),
                            CreatedBy = row["ted_created_by"].ToString(),
                            UpdatedDate = row["ted_updated_date"].ToString(),
                            UpdatedBy = row["ted_updated_by"].ToString(),

                        };
                        DeviceDetailsList.Add(Device);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = DeviceDetailsList;
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

        public Response PutDeviceDetails(DeviceDetailsRequestApi requestAPI)
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

        public Response UpdateDeviceStatus(DeviceDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Device status updated successfully!";
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

    