using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.DataAccess;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class StudentDetailsController : Controller
    {
        //private IStudentDetails _studentdetails;

        private readonly IStudentDetails _studentdetails;

        //DAStudentDetails DAStudentDetails = new DAStudentDetails();

        public StudentDetailsController(IStudentDetails studentdetails)
        {
            _studentdetails = studentdetails;
        }

        // GET: studentdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllStudentDetails(StudentDetailsRequestApi requestAPI)
        {
            var result = _studentdetails.GetAllStudentDetails(requestAPI);

            // Ensure we have a valid list
            if (result.StatusCode == 200 && result.ResultSet is List<StudentDetailsModel> StudentDetailsList)
            {
                foreach (var studentDetails in StudentDetailsList)
                {
                    // Build full URL for image preview
                    studentDetails.Image = Url.Action(
                        "StudentPhotoPreview",
                        "StudentDetails",
                        new { StudentID = studentDetails.StudentID },
                        Request.Url.Scheme
                    );
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStudentDetailsByStudentID(StudentDetailsRequestApi requestAPI)
        {
            var result = _studentdetails.GetStudentDetailsByStudentID(requestAPI);

            if (result.StatusCode == 200 && result.ResultSet is List<StudentDetailsModel> StudentDetailsList)
            {
                foreach (var studentDetails in StudentDetailsList)
                {
                    studentDetails.Image = Url.Action(
                        "StudentPhotoPreview",
                        "StudentDetails",
                        new { StudentID = studentDetails.StudentID },
                        Request.Url.Scheme
                    );
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult AddStudentDetails(StudentDetailsRequestApi requestAPI)
        //{
        //    var result = _studentdetails.AddStudentDetails(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult AddStudentDetails(StudentDetailsRequestApi requestAPI, HttpPostedFileBase file)
        {
            var daStudent = new DAStudentDetails();
            Response res = daStudent.AddStudentDetails(requestAPI);

            if (res.StatusCode == 200)
            {
                string studentId = ((dynamic)res.ResultSet).StudentID.ToString();

                if (file != null && file.ContentLength > 0)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                    string extension = Path.GetExtension(file.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        return Json(new { StatusCode = 400, Message = "Invalid image type" }, JsonRequestBehavior.AllowGet);
                    }

                    string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    // 🔥 Delete old images if exist (same as best practice)
                    var oldFiles = Directory.GetFiles(folderPath, studentId + ".*");
                    foreach (var old in oldFiles)
                        System.IO.File.Delete(old);

                    string fileName = studentId + extension;
                    string filePath = Path.Combine(folderPath, fileName);

                    file.SaveAs(filePath);

                    // 🔥 Update DB with image filename
                    requestAPI.StudentID = studentId;
                    requestAPI.Image = fileName;

                    daStudent.PutStudentDetails(requestAPI);
                }

                return Json(new
                {
                    StatusCode = 200,
                    Message = "Student added successfully",
                    StudentID = studentId
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        //[HttpPost]
        //public ActionResult PutStudentDetails(StudentDetailsRequestApi requestAPI)
        //{
        //    var result = _studentdetails.PutStudentDetails(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult PutStudentDetails(StudentDetailsRequestApi requestAPI, HttpPostedFileBase file)
        {
            var daStudent = new DAStudentDetails();
            Response res;

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                    string extension = Path.GetExtension(file.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        return Json(new { StatusCode = 400, Message = "Invalid image type" }, JsonRequestBehavior.AllowGet);
                    }

                    string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    // 🔥 Remove old image
                    var oldFiles = Directory.GetFiles(folderPath, requestAPI.StudentID + ".*");
                    foreach (var old in oldFiles)
                        System.IO.File.Delete(old);

                    string fileName = requestAPI.StudentID + extension;
                    string filePath = Path.Combine(folderPath, fileName);

                    file.SaveAs(filePath);

                    requestAPI.Image = fileName;
                }

                res = daStudent.PutStudentDetails(requestAPI);
            }
            catch (Exception ex)
            {
                res = new Response
                {
                    StatusCode = 500,
                    Result = "Error: " + ex.Message,
                    ResultSet = null
                };
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        //[HttpPost]
        //public ActionResult UpdateStudentStatus(StudentDetailsRequestApi requestAPI)
        //{
        //    var result = _studentdetails.UpdateStudentStatus(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult StudentPhotoPreview(string StudentID)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"StudentPhotoPreview called with StudentID: {StudentID}");

                if (string.IsNullOrEmpty(StudentID))
                {
                    System.Diagnostics.Debug.WriteLine("StudentID is null or empty");
                    return HttpNotFound("Student ID is required");
                }

                string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";

                if (!Directory.Exists(folderPath))
                {
                    System.Diagnostics.Debug.WriteLine($"Folder not found: {folderPath}");
                    return HttpNotFound("Image directory not found");
                }

                // Search for any file that matches StudentID.*
                string[] files = Directory.GetFiles(folderPath, StudentID + ".*");
                System.Diagnostics.Debug.WriteLine($"Found {files.Length} files for StudentID: {StudentID}");

                if (files.Length == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"No image found for StudentID: {StudentID}");
                    return HttpNotFound($"Image not found for student: {StudentID}");
                }

                string filePath = files[0];
                if (!System.IO.File.Exists(filePath))
                {
                    System.Diagnostics.Debug.WriteLine($"File doesn't exist: {filePath}");
                    return HttpNotFound("Image file not found");
                }

                string ext = Path.GetExtension(filePath).ToLower();
                string mimeType = GetMimeType(ext);

                byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
                System.Diagnostics.Debug.WriteLine($"Successfully loaded image, size: {imageBytes.Length} bytes");

                return File(imageBytes, mimeType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in StudentPhotoPreview: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                return HttpNotFound($"Error loading image: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult TestStudentImagePath(string StudentID = "1")
        {
            string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";
            bool folderExists = Directory.Exists(folderPath);

            var result = new
            {
                StudentID = StudentID,
                FolderExists = folderExists,
                FolderPath = folderPath,
                AllFiles = folderExists ? Directory.GetFiles(folderPath).Select(f => new {
                    FileName = Path.GetFileName(f),
                    FileSize = new FileInfo(f).Length,
                    Extension = Path.GetExtension(f)
                }) : null,
                MatchingFiles = folderExists ? Directory.GetFiles(folderPath, StudentID + ".*").Select(f => Path.GetFileName(f)) : null
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string GetMimeType(string extension)
        {
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".bmp":
                    return "image/bmp";
                case ".webp":
                    return "image/webp";
                default:
                    return "application/octet-stream";
            }
        }

    }
}