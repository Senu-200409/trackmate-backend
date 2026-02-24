using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models
{
    public class RfidModel
    {
        public string LogID { get; set; }
        public string RFIDCode { get; set; }
        public string StudentID { get; set; }
        public string DeviceID { get; set; }
        public string LogDate { get; set; }
        public string LogTime { get; set; }
        public string LogType { get; set; }   // IN / OUT
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}