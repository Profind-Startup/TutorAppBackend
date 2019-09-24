namespace TutorAppBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        public int id { get; set; }

        public int? student_id { get; set; }

        public int? tutor_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reservation_date { get; set; }

        public TimeSpan? reservation_time_start { get; set; }

        public TimeSpan? reservation_time_end { get; set; }

        public int? subject_id { get; set; }

        public int? payment_id { get; set; }

       /* public virtual Payment Payment { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Tutor Tutor { get; set; }*/
    }
}
