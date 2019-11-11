using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorAppBackend.Models
{
    public partial class ReservationDetails
    {
        public int id { get; set; }

       public string tutorNames { get; set; }
        public string tutorLastnames { get; set; }
        public string studentNames { get; set; }
        public string studentLastNames { get; set; }

        public string reservation_date { get; set; }

        public string reservation_time_start { get; set; }

        public string reservation_time_end { get; set; }

        public string subjectname { get; set; }

        public string totalpayment { get; set; }
    }
}