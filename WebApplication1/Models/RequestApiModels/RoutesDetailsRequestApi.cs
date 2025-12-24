using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class RoutesDetailsRequestApi : RequestAPI
    {
        public string BarcodeScript { get; set; }
        public string RfidID { get; set; }
        public string DeviceID { get; set; }
        public string NumberPlate { get; set; }
        public string RouteName { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}