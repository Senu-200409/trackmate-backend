using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IParentDetails
    {
        Response AddParentDetails(ParentDetailsRequestApi requestAPI);
        Response GetAllParentDetails(ParentDetailsRequestApi requestAPI);
        Response GetParentDetailsByParentID(ParentDetailsRequestApi requestAPI);
        Response PutParentDetails(ParentDetailsRequestApi requestAPI);
        Response UpdateParentStatus(ParentDetailsRequestApi requestAPI);
    }
}
