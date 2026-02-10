using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models.RequestApiModels
{
    public class UserDetailsRequestApi : RequestAPI
    {
        public string UserID { get; set; }
        //public string RfidID { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
      //  public string Otp { get; set; }
        public string Status { get; set; }
        //public string CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        public string ProfileImage { get; set; }
    }
}


//namespace TrackMateBackend.Models.RequestApiModels
//{
//    public class UserDetailsRequestAPI
//    {
//        public string ActionType { get; set; }
//        public int? UserID { get; set; }
//        public string Phone { get; set; }
//        public string UserType { get; set; }
//        public string Status { get; set; }
//        public string UserName { get; set; }
//        public string ProfileImage { get; set; }
//    }
//}



//namespace TrackMateBackend.Models.RequestApiModels
//{
//    public class UserDetailsRequestAPI : RequestAPI
//    {
//        public string Phone { get; set; }
//        public string UserType { get; set; }    // O, D, P
//        public string UserName { get; set; }
//        public string ProfileImage { get; set; }
//    }
//}
