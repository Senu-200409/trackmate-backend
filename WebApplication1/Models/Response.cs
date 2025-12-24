using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMateBackend.Models
{
    public class Response
    {
        public int StatusCode { get; set; } = 404;
        public string Result { get; set; }
        public object ResultSet { get; set; }

    }
}