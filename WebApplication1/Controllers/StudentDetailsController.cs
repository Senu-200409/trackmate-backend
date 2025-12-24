using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStudentDetailsByStudentID(StudentDetailsRequestApi requestAPI)
        {
            var result = _studentdetails.GetStudentDetailsByStudentID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddStudentDetails(StudentDetailsRequestApi requestAPI)
        {
            var result = _studentdetails.AddStudentDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutStudentDetails(StudentDetailsRequestApi requestAPI)
        {
            var result = _studentdetails.PutStudentDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateStudentStatus(StudentDetailsRequestApi requestAPI)
        {
            var result = _studentdetails.UpdateStudentStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}