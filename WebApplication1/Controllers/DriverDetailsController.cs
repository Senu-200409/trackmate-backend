using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class DriverDetailsController : Controller
    {
        //private IDriverDetails _driverdetails;

        private readonly IDriverDetails _driverdetails;

        //DADriverDetails DADeviceDetails = new DADeviceDetails();

        public DriverDetailsController(IDriverDetails driverdetails)
        {
            _driverdetails = driverdetails;
        }

        // GET: driverdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllDriverDetails(DriverDetailsRequestApi requestAPI)
        {
            var result = _driverdetails.GetAllDriverDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDriverDetailsByDriverID(DriverDetailsRequestApi requestAPI)
        {
            var result = _driverdetails.GetDriverDetailsByDriverID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddDriverDetails(DriverDetailsRequestApi requestAPI)
        {
            var result = _driverdetails.AddDriverDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutDriverDetails(DriverDetailsRequestApi requestAPI)
        {
            var result = _driverdetails.PutDriverDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateDriverStatus(DriverDetailsRequestApi requestAPI)
        {
            var result = _driverdetails.UpdateDriverStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}