using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class SchoolDetailsController : Controller
    {
        //private ISchoolDetails _schooldetails;

        private readonly ISchoolDetails _schooldetails;

        //DASchoolDetails DASchoolDetails = new DASchoolDetails();

        public SchoolDetailsController(ISchoolDetails schooldetails)
        {
            _schooldetails = schooldetails;
        }

        // GET: schooldetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllSchoolDetails(SchoolDetailsRequestApi requestAPI)
        {
            var result = _schooldetails.GetAllSchoolDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSchoolDetailsBySchoolID(SchoolDetailsRequestApi requestAPI)
        {
            var result = _schooldetails.GetSchoolDetailsBySchoolID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddSchoolDetails(SchoolDetailsRequestApi requestAPI)
        {
            var result = _schooldetails.AddSchoolDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutSchoolDetails(SchoolDetailsRequestApi requestAPI)
        {
            var result = _schooldetails.PutSchoolDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult UpdateSchoolStatus(SchoolDetailsRequestApi requestAPI)
        //{
        //    var result = _schooldetails.UpdateSchoolStatus(requestAPI);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}