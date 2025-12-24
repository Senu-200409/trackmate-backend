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
    public class NotificationDetailsController : Controller
    {
        //private INotificationDetails _notificationdetails;

        private readonly INotificationDetails _notificationdetails;

        //DANotificationDetails DANotificationDetails = new DANotificationDetails();

        public NotificationDetailsController(INotificationDetails notificationdetails)
        {
            _notificationdetails = notificationdetails;
        }

        // GET: notificationdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllNotificationDetails(NotificationDetailsRequestApi requestAPI)
        {
            var result = _notificationdetails.GetAllNotificationDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetNotificationDetailsByNotificationID(NotificationDetailsRequestApi requestAPI)
        {
            var result = _notificationdetails.GetNotificationDetailsByNotificationID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddNotificationDetails(NotificationDetailsRequestApi requestAPI)
        {
            var result = _notificationdetails.AddNotificationDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutNotificationDetails(NotificationDetailsRequestApi requestAPI)
        {
            var result = _notificationdetails.PutNotificationDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateNotificationStatus(NotificationDetailsRequestApi requestAPI)
        {
            var result = _notificationdetails.UpdateNotificationStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}