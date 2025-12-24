using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IDriverDetails
    {
        Response AddDriverDetails(DriverDetailsRequestApi requestAPI);
        Response GetAllDriverDetails(DriverDetailsRequestApi requestAPI);
        Response GetDriverDetailsByDriverID(DriverDetailsRequestApi requestAPI);
        Response PutDriverDetails(DriverDetailsRequestApi requestAPI);
        Response UpdateDriverStatus(DriverDetailsRequestApi requestAPI);
    }
}
