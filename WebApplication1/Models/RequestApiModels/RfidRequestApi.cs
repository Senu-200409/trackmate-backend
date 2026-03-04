using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class RfidRequestApi : RequestAPI
    {
        public string Userid { get; set; }
        public string LogID { get; set; }
        public string RFIDCode { get; set; }
        public string StudentID { get; set; }
        public string DeviceID { get; set; }
        public string LogDate { get; set; }
        public string LogTime { get; set; }
       // public string LogType { get; set; }   // IN / OUT
        public string Status { get; set; }
    }
}