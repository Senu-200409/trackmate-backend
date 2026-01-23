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
    public class UserDetailsController : Controller
    {
        //private IUserDetails _userdetails;

        private readonly IUserDetails _userdetails;

        //DAUserDetails DAStudentDetails = new DAStudentDetails();

        public UserDetailsController(IUserDetails userdetails)
        {
            _userdetails = userdetails;
        }
        
        // GET: UserDetails
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult RegisterUser(UserDetailsRequestApi requestAPI)
        //{
        //    var result = _userdetails.RegisterUser(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult RegisterUser(UserDetailsRequestApi requestAPI, HttpPostedFileBase file)
        {
            Response res = _userdetails.RegisterUser(requestAPI);

            if (res.StatusCode != 200)
                return Json(res, JsonRequestBehavior.AllowGet);
            {
                string userId = ((dynamic)res.ResultSet).UserID.ToString();

                // DEBUG logs
                System.Diagnostics.Debug.WriteLine($"File is null: {file == null}");

                if (file != null && file.ContentLength > 0)
                {
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                    string extension = Path.GetExtension(file.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        return Json(new { StatusCode = 400, Message = "Invalid file type" },
                                    JsonRequestBehavior.AllowGet);
                    }

                    string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fileName = userId + extension;
                    string filePath = Path.Combine(folderPath, fileName);

                    // Save image
                    file.SaveAs(filePath);

                    // Save image name in DB (like InventoryPro)
                    string imagePathToSaveInDB = fileName;

                    var updateRequest = new UserDetailsRequestApi
                    {
                        UserID = userId,
                        ProfileImage = imagePathToSaveInDB,
                        Phone = requestAPI.Phone,
                        UserType = requestAPI.UserType,
                        Status = requestAPI.Status
                    };

                    Response updateRes = _userdetails.UpdateUser(updateRequest);

                    if (updateRes.StatusCode == 200)
                    {
                        return Json(new
                        {
                            StatusCode = 200,
                            Message = "User and image added successfully!",
                            UserID = userId,
                            ImageSavedAs = fileName,
                            DatabaseUpdated = true
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        StatusCode = 200,
                        Message = "User added successfully (no image uploaded)!",
                        UserID = userId
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult LoginUser(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.LoginUser(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //[HttpGet]
        //public ActionResult GetAllUsers(UserDetailsRequestApi requestAPI)
        //{
        //    var result = _userdetails.GetAllUsers(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetAllUsers(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.GetAllUsers(requestAPI);

            if (result.StatusCode == 200 && result.ResultSet is List<UserDetailsModel> users)
            {
                foreach (var user in users)
                {
                    user.ProfileImage = Url.Action(
                        "ProfileImagePreview",
                        "UserDetails",
                        new { UserID = user.UserID },
                        Request.Url.Scheme
                    );
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }




        //[HttpGet]
        //public ActionResult GetUserByUserID(UserDetailsRequestApi requestAPI)
        //{
        //    var result = _userdetails.GetUserByUserID(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetUserByUserID(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.GetUserByUserID(requestAPI);

            // Attach image URL
            if (result.StatusCode == 200 && result.ResultSet is List<UserDetailsModel> users)
            {
                foreach (var user in users)
                {
                    user.ProfileImage = Url.Action(
                        "ProfileImagePreview",
                        "UserDetails",
                        new { UserID = user.UserID },
                        Request.Url.Scheme
                    );
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //[HttpPost]
        //public ActionResult UpdateUser(UserDetailsRequestApi requestAPI)
        //{
        //    var result = _userdetails.UpdateUser(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult UpdateUser(UserDetailsRequestApi requestAPI, HttpPostedFileBase file)
        {
            Response res = new Response();
            var daUser = new DAUserDetails();

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string extension = Path.GetExtension(file.FileName).ToLower();
                    string fileName = requestAPI.UserID + extension;
                    string filePath = Path.Combine(folderPath, fileName);

                    // delete old image
                    var oldFiles = Directory.GetFiles(folderPath, requestAPI.UserID + ".*");
                    foreach (var old in oldFiles)
                        System.IO.File.Delete(old);

                    file.SaveAs(filePath);

                    requestAPI.ProfileImage = fileName;
                }

                res = daUser.UpdateUser(requestAPI);
            }
            catch (Exception ex)
            {
                res.StatusCode = 500;
                res.Result = ex.Message;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult UpdateUserStatus(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.UpdateUserStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProfileImagePreview(string UserID)
        {
            try
            {
                string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";

                if (!Directory.Exists(folderPath))
                    return HttpNotFound("Image directory not found");

                string[] files = Directory.GetFiles(folderPath, UserID + ".*");

                if (files.Length == 0)
                    return HttpNotFound("Image not found");

                string filePath = files[0];
                string ext = Path.GetExtension(filePath).ToLower();
                string mimeType = GetMimeType(ext);

                byte[] imageBytes = System.IO.File.ReadAllBytes(filePath);
                return File(imageBytes, mimeType);
            }
            catch (Exception ex)
            {
                return HttpNotFound("Error loading image: " + ex.Message);
            }
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
    