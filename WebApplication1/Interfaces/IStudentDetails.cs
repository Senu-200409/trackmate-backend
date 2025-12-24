using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMateBackend.Models;
using TrackMateBackend.Models.RequestApiModels;

namespace TrackMateBackend.Interfaces
{
    public interface IStudentDetails
    {
        Response AddStudentDetails(StudentDetailsRequestApi requestAPI);
        Response GetAllStudentDetails(StudentDetailsRequestApi requestAPI);
        Response GetStudentDetailsByStudentID(StudentDetailsRequestApi requestAPI);
        Response PutStudentDetails(StudentDetailsRequestApi requestAPI);
        Response UpdateStudentStatus(StudentDetailsRequestApi requestAPI);
    }
}
