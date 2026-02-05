using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models
{
    public class UserDetailsModel
    {
        public string UserID { get; set; }
        // public string RfidID { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string Otp { get; set; }
        public string OtpExpiry { get; set; }
        public string lastLogin { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}


//namespace TrackMateBackend.Models.RequestApiModels
//{
//    public class RequestAPI
//    {
//        public string ActionType { get; set; }   // For procedure action
//        public string UserID { get; set; }       // string type for consistency
//        public string Status { get; set; }       // A/I/P
//    }
//}
