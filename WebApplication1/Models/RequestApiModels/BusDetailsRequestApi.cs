using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class BusDetailsRequestApi : RequestAPI
    {
        public string Uid { get; set; }
        public string NumberPlate { get; set; }
        public string DriverID { get; set; }
        public string Vehicle { get; set; }
        public string SheetCount { get; set; }
        public string LicenseExpiry { get; set; }
        public string InsuranceExpiry { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }
        //public string CreateDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
    }
}