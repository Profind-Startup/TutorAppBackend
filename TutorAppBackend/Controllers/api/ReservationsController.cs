using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TutorAppBackend.Models;

namespace TutorAppBackend.Controllers.api
{
    public class ReservationsController : BaseApiController
    {
        public ReservationsController() : base() { }

        //GET: api/Students/5/Reservations
        [Route("api/Reservations/{id}/details")]
        public ReservationDetails GetReservationDetail(int id)
        {
            ReservationDetails reservationDetail;

            Reservation reservation = _context.Reservation.Find(id);

            Tutor tutor = _context.Tutor.Find(reservation.tutor_id);

            Student student = _context.Student.Find(reservation.student_id);

            User userSt = _context.User.Find(student.user_id);
            User userTt = _context.User.Find(tutor.user_id);

            Subject subject = _context.Subject.Find(reservation.subject_id);

            reservationDetail = new ReservationDetails();

            reservationDetail.id = reservation.id;

            reservationDetail.reservation_date = reservation.reservation_date.ToString();

            reservationDetail.reservation_time_start = reservation.reservation_time_start.ToString();
            reservationDetail.reservation_time_end = reservation.reservation_time_end.ToString();
            reservationDetail.studentNames = userSt.names;
            reservationDetail.studentNames = userSt.last_names;
            reservationDetail.tutorNames = userTt.names;
            reservationDetail.tutorLastnames = userTt.last_names;
            reservationDetail.subjectname = subject.name;
            reservationDetail.totalpayment = "0";
          
            return reservationDetail;
        }

        // GET: api/Reservations
        public IQueryable<Reservation> GetReservation()
        {
            return _context.Reservation;
        }

        // GET: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            Reservation reservation = _context.Reservation.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reservations
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reservation.Add(reservation);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reservation.id }, reservation);
        }

        // DELETE: api/Reservations/5
        [ResponseType(typeof(Reservation))]
        public IHttpActionResult DeleteReservation(int id)
        {
            Reservation reservation = _context.Reservation.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservation.Remove(reservation);
            _context.SaveChanges();

            return Ok(reservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Count(e => e.id == id) > 0;
        }
    }
}