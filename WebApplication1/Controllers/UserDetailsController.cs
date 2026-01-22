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
            Response res = new Response();

            try
            {
                //string imagePath = null;

                // 1️⃣ Image upload
                if (file != null && file.ContentLength > 0)
                {
                    string folderPath = @"C:\Users\senul\Desktop\Office Assignment\trackmate backend github\trackmate-backend\images";

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string extension = Path.GetExtension(file.FileName).ToLower();
                    string[] allowed = { ".jpg", ".jpeg", ".png" };

                    if (!allowed.Contains(extension))
                    {
                        return Json(new { StatusCode = 400, Message = "Invalid image type" },
                                    JsonRequestBehavior.AllowGet);
                    }

                    // phone / userid as filename
                    string fileName = requestAPI.Phone + extension;
                    string filePath = Path.Combine(folderPath, fileName);

                    file.SaveAs(filePath);

                    //imagePath = "/ProfileImages/" + fileName;
                    //requestAPI.ProfileImagePath = imagePath;
                    requestAPI.ProfileImage = "/ProfileImages/" + fileName;
                }

                // 2️⃣ Save user details (with image path)
                res = _userdetails.RegisterUser(requestAPI);
            }
            catch (Exception ex)
            {
                res.StatusCode = 500;
                res.Result = ex.Message;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult LoginUser(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.LoginUser(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult GetAllUsers(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.GetAllUsers(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult GetUserByUserID(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.GetUserByUserID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult UpdateUser(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.UpdateUser(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        [HttpPost]
        public ActionResult UpdateUserStatus(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.UpdateUserStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
    