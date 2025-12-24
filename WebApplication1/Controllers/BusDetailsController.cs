using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class BusDetailsController : Controller
    {
        //private IBusDetails _busdetails;

        private readonly IBusDetails _busdetails;

        //DABusDetails DABusDetails = new DABusDetails();

        public BusDetailsController(IBusDetails busdetails)
        {
            _busdetails = busdetails;
        }

        // GET: busdetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllBusDetails(BusDetailsRequestApi requestAPI)
        {
            var result = _busdetails.GetAllBusDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBusDetailsByNumberplate(BusDetailsRequestApi requestAPI)
        {
            var result = _busdetails.GetBusDetailsByNumberplate(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddBusDetails(BusDetailsRequestApi requestAPI)
        {
            var result = _busdetails.AddBusDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutBusDetails(BusDetailsRequestApi requestAPI)
        {
            var result = _busdetails.PutBusDetails(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateBusStatus(BusDetailsRequestApi requestAPI)
        {
            var result = _busdetails.UpdateBusStatus(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}