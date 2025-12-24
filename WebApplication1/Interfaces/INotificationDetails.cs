using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface INotificationDetails
    {
        Response AddNotificationDetails(NotificationDetailsRequestApi requestAPI);
        Response GetAllNotificationDetails(NotificationDetailsRequestApi requestAPI);
        Response GetNotificationDetailsByNotificationID(NotificationDetailsRequestApi requestAPI);
        Response PutNotificationDetails(NotificationDetailsRequestApi requestAPI);
        Response UpdateNotificationStatus(NotificationDetailsRequestApi requestAPI);
    }
}
