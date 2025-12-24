using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IDeviceDetails
    {
        Response AddDeviceDetails(DeviceDetailsRequestApi requestAPI);
        Response GetAllDeviceDetails(DeviceDetailsRequestApi requestAPI);
        Response GetDeviceDetailsByDeviceID(DeviceDetailsRequestApi requestAPI);
        Response PutDeviceDetails(DeviceDetailsRequestApi requestAPI);
        Response UpdateDeviceStatus(DeviceDetailsRequestApi requestAPI);
    }
}
