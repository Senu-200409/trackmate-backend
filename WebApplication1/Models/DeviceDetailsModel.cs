using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models
{
    public class DeviceDetailsModel
    {
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string NumberPlate { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
