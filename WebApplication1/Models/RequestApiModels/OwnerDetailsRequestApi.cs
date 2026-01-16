using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class OwnerDetailsRequestApi : RequestAPI
    {
        public string Uid { get; set; }
        public string OwnerID { get; set; }
        public string UserID { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNo { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        //public string CreateDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
    }
}