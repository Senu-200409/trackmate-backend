using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models
{
    public class StudentDetailsModel
    {
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public string RfidID { get; set; }
        public string ParentID { get; set; }
        public string SchoolID { get; set; }
        public string BarcodeScript { get; set; }
        public string NumberPlate { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

