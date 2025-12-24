using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.DataAccess;
using TrackMateBackend.Interfaces;
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

        
        [HttpPost]
        public ActionResult RegisterUser(UserDetailsRequestApi requestAPI)
        {
            var result = _userdetails.RegisterUser(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
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
    