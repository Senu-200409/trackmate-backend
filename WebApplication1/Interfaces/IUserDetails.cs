using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IUserDetails
    {
        Response RegisterUser(UserDetailsRequestApi requestAPI);
        Response LoginUser(UserDetailsRequestApi requestAPI);
        Response GetAllUsers(UserDetailsRequestApi requestAPI);
        Response GetUserByUserID(UserDetailsRequestApi requestAPI);
        Response UpdateUser(UserDetailsRequestApi requestAPI);
        Response UpdateUserStatus(UserDetailsRequestApi requestAPI);
        Response SendOtp(UserDetailsRequestApi requestAPI);
    }
}


//using TrackMateBackend.Models;
//using TrackMateBackend.Models.RequestApiModels;

//namespace TrackMateBackend.Interfaces
//{
//    public interface IUserDetails
//    {
//        Response RegisterUser(UserDetailsRequestAPI request);
//        Response SendOtp(UserDetailsRequestAPI request);
//        Response GetUserById(UserDetailsRequestAPI request);
//        Response GetAllUsers(UserDetailsRequestAPI request);
//        Response UpdateUser(UserDetailsRequestAPI request);
//        Response DeleteUser(UserDetailsRequestAPI request);
//    }
//}
