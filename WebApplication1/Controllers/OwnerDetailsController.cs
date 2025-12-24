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
    public class OwnerDetailsController : Controller
    {
        //private IOwnerDetails _ownerdetails;

        private readonly IOwnerDetails _ownerdetails;

        //DAOwnerDetails DAOwnerDetails = new DAOwnerDetails();

        public OwnerDetailsController(IOwnerDetails ownerdetails)
        {
            _ownerdetails = ownerdetails;
        }

        // GET: ownerdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllOwnerDetails(OwnerDetailsRequestApi requestAPI)
        {
            var result = _ownerdetails.GetAllOwnerDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetOwnerDetailsByOwnerID(OwnerDetailsRequestApi requestAPI)
        {
            var result = _ownerdetails.GetOwnerDetailsByOwnerID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddOwnerDetails(OwnerDetailsRequestApi requestAPI)
        {
            var result = _ownerdetails.AddOwnerDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutOwnerDetails(OwnerDetailsRequestApi requestAPI)
        {
            var result = _ownerdetails.PutOwnerDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateOwnerStatus(OwnerDetailsRequestApi requestAPI)
        {
            var result = _ownerdetails.UpdateOwnerStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}