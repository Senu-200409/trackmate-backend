using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class ParentDetailsController : Controller
    {
        //private IParentDetails _parentdetails;

        private readonly IParentDetails _parentdetails;

        //DAParentDetails DAParentDetails = new DAParentDetails();

        public ParentDetailsController(IParentDetails parentdetails)
        {
            _parentdetails = parentdetails;
        }

        // GET: parentdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllParentDetails(ParentDetailsRequestApi requestAPI)
        {
            var result = _parentdetails.GetAllParentDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetParentDetailsByParentID(ParentDetailsRequestApi requestAPI)
        {
            var result = _parentdetails.GetParentDetailsByParentID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddParentDetails(ParentDetailsRequestApi requestAPI)
        {
            var result = _parentdetails.AddParentDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutParentDetails(ParentDetailsRequestApi requestAPI)
        {
            var result = _parentdetails.PutParentDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateParentStatus(ParentDetailsRequestApi requestAPI)
        {
            var result = _parentdetails.UpdateParentStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}