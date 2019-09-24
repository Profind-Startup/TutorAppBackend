namespace TutorAppBackend.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TutorAppBD : DbContext
    {
        public TutorAppBD()
            : base("name=TutorAppBD")
        {
        }

        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Tutor> Tutor { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        /*    modelBuilder.Entity<Payment>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.Payment)
                .HasForeignKey(e => e.payment_id);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.student_id);
                */
            modelBuilder.Entity<Subject>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.area)
                .IsUnicode(false);

           /* modelBuilder.Entity<Subject>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.subject_id);*/

            modelBuilder.Entity<Tutor>()
                .Property(e => e.academic_group_name)
                .IsUnicode(false);

            modelBuilder.Entity<Tutor>()
                .Property(e => e.academic_group_address)
                .IsUnicode(false);

           /* modelBuilder.Entity<Tutor>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.Tutor)
                .HasForeignKey(e => e.tutor_id);*/

            modelBuilder.Entity<User>()
                .Property(e => e.names)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.last_names)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            /*modelBuilder.Entity<User>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tutor)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.user_id);*/
        }
    }
}
