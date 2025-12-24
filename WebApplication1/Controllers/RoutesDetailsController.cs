using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class RoutesDetailsController : Controller
    {
        //private IRoutesDetails _routesdetails;

        private readonly IRoutesDetails _routesdetails;

        //DARoutesDetails DARoutesDetails = new DARoutesDetails();

        public RoutesDetailsController(IRoutesDetails routesdetails)
        {
            _routesdetails = routesdetails;
        }

        // GET: routesdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllRoutesDetails(RoutesDetailsRequestApi requestAPI)
        {
            var result = _routesdetails.GetAllRoutesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRoutesDetailsByBarcodeScript(RoutesDetailsRequestApi requestAPI)
        {
            var result = _routesdetails.GetRoutesDetailsByBarcodeScript(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddRoutesDetails(RoutesDetailsRequestApi requestAPI)
        {
            var result = _routesdetails.AddRoutesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutRoutesDetails(RoutesDetailsRequestApi requestAPI)
        {
            var result = _routesdetails.PutRoutesDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateRoutesStatus(RoutesDetailsRequestApi requestAPI)
        {
            var result = _routesdetails.UpdateRoutesStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}