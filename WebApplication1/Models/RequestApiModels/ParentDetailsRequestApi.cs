using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class ParentDetailsRequestApi : RequestAPI
    {
        public string Uid { get; set; }
        public string ParentID { get; set; }
        public string UserID { get; set; }
        public string ParentName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string ContactNo2 { get; set; }
        public string Status { get; set; }
        //public string CreateDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
    }
}