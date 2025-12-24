using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class DeviceDetailsRequestApi : RequestAPI
    {
        public string DeviceID { get; set; }
        public string Uid { get; set; }
        public string DeviceName { get; set; }
        public string NumberPlate { get; set; }
        public string Status { get; set; }
  
    }
}