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
    public class DAStudentDetails : IStudentDetails
    {
        private readonly string ProcedureName = "StudentManagement";

        public Response AddStudentDetails(StudentDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "1";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Student added successfully!";
                }
                else
                {
                    result.StatusCode = 500;
                    result.Result = res.ExceptionMessage;
                }
            }
            return result;
        }

        public Response GetAllStudentDetails(StudentDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "2";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<StudentDetailsModel> StudentDetailsList = new List<StudentDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        StudentDetailsModel Student = new StudentDetailsModel
                        {

                            StudentID = row["ttd_student_id"].ToString(),
                            FullName = row["ttd_full_name"].ToString(),
                            Age = row["ttd_age"].ToString(),
                            RfidID = row["ttc_rfid_id"].ToString(),
                            ParentID = row["ttd_parent_id"].ToString(),
                            SchoolID = row["ttd_school_id"].ToString(),
                            BarcodeScript = row["ttd_barcode_script"].ToString(),
                            NumberPlate = row["ttd_number_plate"].ToString(),
                            Status = row["ttd_status"].ToString(),
                            CreateDate = row["ttd_create_date"].ToString(),
                            CreatedBy = row["ttd_created_by"].ToString(),
                            UpdatedDate = row["ttd_updated_date"].ToString(),
                            UpdatedBy = row["ttd_updated_by"].ToString(),

                        };
                        StudentDetailsList.Add(Student);
                    }

                    result.StatusCode = 200;
                    result.ResultSet = StudentDetailsList;
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

        public Response GetStudentDetailsByStudentID(StudentDetailsRequestApi requestAPI)
        {

            Response result = new Response();
            requestAPI.ActionType = "3";

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                if (res.ResultStatusCode == "1")
                {
                    List<StudentDetailsModel> StudentDetailsList = new List<StudentDetailsModel>();
                    foreach (DataRow row in res.ResultDataTable.Rows)
                    {
                        StudentDetailsModel Student = new StudentDetailsModel
                        {
                            StudentID = row["ttd_student_id"].ToString(),
                            FullName = row["ttd_full_name"].ToString(),
                            Age = row["ttd_age"].ToString(),
                            RfidID = row["ttc_rfid_id"].ToString(),
                            ParentID = row["ttd_parent_id"].ToString(),
                            SchoolID = row["ttd_school_id"].ToString(),
                            BarcodeScript = row["ttd_barcode_script"].ToString(),
                            NumberPlate = row["ttd_number_plate"].ToString(),
                            Status = row["ttd_status"].ToString(),
                            CreateDate = row["ttd_create_date"].ToString(),
                            CreatedBy = row["ttd_created_by"].ToString(),
                            UpdatedDate = row["ttd_updated_date"].ToString(),
                            UpdatedBy = row["ttd_updated_by"].ToString(),

                        };
                        StudentDetailsList.Add(Student);
                    }
                    result.StatusCode = 200;
                    result.ResultSet = StudentDetailsList;
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

        public Response PutStudentDetails(StudentDetailsRequestApi requestAPI)
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

        public Response UpdateStudentStatus(StudentDetailsRequestApi requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "5"; // Status Update

            using (var dbConnect = new DBconnect())
            {
                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                if (res.ResultStatusCode == "1")
                {
                    result.StatusCode = 200;
                    result.Result = "Student status updated successfully!";
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