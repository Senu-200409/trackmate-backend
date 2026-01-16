using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class DriverDetailsRequestApi : RequestAPI
    {
        public string Uid { get; set; }
        public string DriverID { get; set; }
        public string UserID { get; set; }
        public string DriverName { get; set; }
        public string PhoneNo { get; set; }
        public string LicenseNo { get; set; }
        public string LicenseType { get; set; }
        public string Status { get; set; }
        //public string CreateDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
    }
}