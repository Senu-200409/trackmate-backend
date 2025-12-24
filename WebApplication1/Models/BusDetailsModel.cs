using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models
{
    public class BusDetailsModel
    {
        public string NumberPlate { get; set; }
        public string DriverID { get; set; }
        public string SchoolID { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy  { get; set; }
    }
}


