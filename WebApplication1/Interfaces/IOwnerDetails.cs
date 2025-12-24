using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IOwnerDetails
    {
        Response AddOwnerDetails(OwnerDetailsRequestApi requestAPI);
        Response GetAllOwnerDetails(OwnerDetailsRequestApi requestAPI);
        Response GetOwnerDetailsByOwnerID(OwnerDetailsRequestApi requestAPI);
        Response PutOwnerDetails(OwnerDetailsRequestApi requestAPI);
        Response UpdateOwnerStatus(OwnerDetailsRequestApi requestAPI);
    }
}
