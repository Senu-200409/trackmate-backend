using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class NotificationDetailsRequestApi : RequestAPI
    {
        public string NotificationID { get; set; }
        public string SentDate { get; set; }
        public string ParentID { get; set; }
        public string OwnerID { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}