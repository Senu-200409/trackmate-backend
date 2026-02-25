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
    public class DARfid : IRfid
    {
        private readonly string ProcedureName = "RFIDDailyLogsManagement";

        
        public Response AddRfid(RfidRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "RFID log inserted successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

       
        public Response GetAllRfid(RfidRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<RfidModel> rfidList = new List<RfidModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        RfidModel log = new RfidModel
                        {
                            LogID = row["trdl_id"].ToString(),
                            RFIDCode = row["trdl_rfid_code"].ToString(),
                            StudentID = row["trdl_student_id"].ToString(),
                            DeviceID = row["trdl_device_id"].ToString(),
                            LogDate = row["trdl_date"].ToString(),
                            LogTime = row["trdl_log_time"].ToString(),
                            LogType = row["trdl_log_type"].ToString(),
                            Status = row["trdl_status"].ToString(),
                            CreateDate = row["trdl_create_date"].ToString(),
                            CreatedBy = row["trdl_created_by"].ToString(),
                            UpdatedDate = row["trdl_updated_date"].ToString(),
                            UpdatedBy = row["trdl_updated_by"].ToString()
                        };

                        rfidList.Add(log);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = rfidList;
                }
                else
                {
                    LogHandler.WriteToLog(res.ExceptionMessage,
                        System.Reflection.MethodBase.GetCurrentMethod().Name);

                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        
        public Response GetRfidByLogID(RfidRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    List<RfidModel> rfidList = new List<RfidModel>();

                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        RfidModel log = new RfidModel
                        {
                            LogID = row["trdl_id"].ToString(),
                            RFIDCode = row["trdl_rfid_code"].ToString(),
                            StudentID = row["trdl_student_id"].ToString(),
                            DeviceID = row["trdl_device_id"].ToString(),
                            LogDate = row["trdl_date"].ToString(),
                            LogTime = row["trdl_log_time"].ToString(),
                            LogType = row["trdl_log_type"].ToString(),
                            Status = row["trdl_status"].ToString()
                        };

                        rfidList.Add(log);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = rfidList;
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

      
        public Response PutRfid(RfidRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "4";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                result.StatusCode = res.ResultStatusCode == "1" ? 200 : 400;
                result.Result = res.Result;
            }

            return result;
        }
    }
}