using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IBusDetails
    {
        Response AddBusDetails(BusDetailsRequestApi requestAPI);
        Response GetAllBusDetails(BusDetailsRequestApi requestAPI);
        Response GetBusDetailsByNumberplate(BusDetailsRequestApi requestAPI);
        Response PutBusDetails(BusDetailsRequestApi requestAPI);
        Response UpdateBusStatus(BusDetailsRequestApi requestAPI);
    }
}
