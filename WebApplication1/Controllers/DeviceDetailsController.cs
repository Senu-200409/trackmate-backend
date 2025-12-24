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
    public class DeviceDetailsController : Controller
    {
        

        private readonly IDeviceDetails _devicedetails;

        

        public DeviceDetailsController(IDeviceDetails devicedetails)
        {
            _devicedetails = devicedetails;
        }

        // GET: devicedetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllDeviceDetails(DeviceDetailsRequestApi requestAPI)
        {
            var result = _devicedetails.GetAllDeviceDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDeviceDetailsByDeviceID(DeviceDetailsRequestApi requestAPI)
        {
            var result = _devicedetails.GetDeviceDetailsByDeviceID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddDeviceDetails(DeviceDetailsRequestApi requestAPI)
        {
            var result = _devicedetails.AddDeviceDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutDeviceDetails(DeviceDetailsRequestApi requestAPI)
        {
            var result = _devicedetails.PutDeviceDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateDeviceStatus(DeviceDetailsRequestApi requestAPI)
        {
            var result = _devicedetails.UpdateDeviceStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}