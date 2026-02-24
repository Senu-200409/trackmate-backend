using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMateBackend.Interfaces;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Controllers
{
    public class RfidController : Controller
    {
        //private IRfid _rfid;

        private readonly IRfid _rfid;

        //DARfid DARfid = new DARfid();

        public RfidController(IRfid rfid)
        {
            _rfid = rfid;
        }

        // GET: Rfid
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllRfid(RfidRequestApi requestAPI)
        {
            var result = _rfid.GetAllRfid(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRfidByLogID(RfidRequestApi requestAPI)
        {
            var result = _rfid.GetRfidByLogID(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddRfid(RfidRequestApi requestAPI)
        {
            var result = _rfid.AddRfid(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PutRfid(RfidRequestApi requestAPI)
        {
            var result = _rfid.PutRfid(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}