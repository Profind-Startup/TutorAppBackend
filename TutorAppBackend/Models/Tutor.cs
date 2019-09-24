namespace TutorAppBackend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tutor")]
    public partial class Tutor
    {
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutor()
        {
            Reservation = new HashSet<Reservation>();
        }*/

        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(100)]
        public string academic_group_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? academic_group_foundation_date { get; set; }

        [StringLength(100)]
        public string academic_group_address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth_date { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }

        public virtual User User { get; set; }*/
    }
}
