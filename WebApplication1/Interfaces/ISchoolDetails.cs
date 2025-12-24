using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface ISchoolDetails
    {
        Response AddSchoolDetails(SchoolDetailsRequestApi requestAPI);
        Response GetAllSchoolDetails(SchoolDetailsRequestApi requestAPI);
        Response GetSchoolDetailsBySchoolID(SchoolDetailsRequestApi requestAPI);
        Response PutSchoolDetails(SchoolDetailsRequestApi requestAPI);
        Response UpdateSchoolStatus(SchoolDetailsRequestApi requestAPI);
    }
}
