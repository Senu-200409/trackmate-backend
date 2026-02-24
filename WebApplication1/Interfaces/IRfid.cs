using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IRfid
    {
        Response AddRfid(RfidRequestApi requestAPI);
        Response GetAllRfid(RfidRequestApi requestAPI);
        Response GetRfidByLogID(RfidRequestApi requestAPI);
        Response PutRfid(RfidRequestApi requestAPI);
    }
}
