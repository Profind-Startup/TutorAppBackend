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
    public class TutorsController : BaseApiController
    {
        public TutorsController() : base() { }

        //GET: api/Tutors/5/User
        [Route("api/Tutors/{id}/User")]
        public User GetTutorUser(int tutorid)
        {
            Tutor tutor = _context.Tutor.Find(tutorid);
            if (tutor == null)
            {
                return null;
                //  return NotFound();
            }
            return _context.User.Where(x => x.id == tutorid).FirstOrDefault();
        }



        //GET: api/Tutors/5/Reservations
        [Route("api/Tutors/{id}/Reservations")]
        public IQueryable<Reservation> GetTutorReservations(int id)
        {
            Tutor tutor = _context.Tutor.Find(id);
            if (tutor == null)
            {
                return null;
              //  return NotFound();
            }
            return _context.Reservation.Where(x => x.tutor_id == id); 
        }

        //GET: api/Tutors/5/Subject
        [Route("api/Tutors/{id}/Subjects")]
        public IQueryable<Subject> GetTutorSubjects(int id)
        {
            Tutor tutor = _context.Tutor.Find(id);
            if (tutor == null)
            {
                return null;
                //  return NotFound();
            }


                var subjects = _context.Subject.Where(x => x.id_tutor == id);

                

            return subjects;
        }

       //GET: api/Tutors/5/Reservations/5/Subject
       /* [Route("api/Tutors/{id}/Reservations/Subjects")]
        public IQueryable<Subject> GetTutorReservationsSubjects(int id)
        {
            Tutor tutor = _context.Tutor.Find(id);
            if (tutor == null)
            {
                return null;
                //  return NotFound();
            }

           
           var reservations = _context.Reservation.Where(x => x.tutor_id == id);

            if (reservations == null)
            {
                return null;
                //  return NotFound();
            }


            IQueryable<Subject> subjects = _context.Subject.Where(x => x.id == reservations.FirstOrDefault().subject_id);


            foreach (Reservation r in reservations)
            {
              
                var subjects2 = _context.Subject.Where(x => x.id == r.subject_id);

                subjects.Union(subjects2);
            }

            if(subjects == null)
            {
                return null;
            }
            
            return subjects;
        }
        */
        // GET: api/Tutors
        public IQueryable<Tutor> GetTutor()
        {
            return _context.Tutor;
        }

        // GET: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult GetTutor(int id)
        {
            Tutor tutor = _context.Tutor.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTutor(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.id)
            {
                return BadRequest();
            }

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutors
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tutor.Add(tutor);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tutor.id }, tutor);
        }

        // DELETE: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public IHttpActionResult DeleteTutor(int id)
        {
            Tutor tutor = _context.Tutor.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutor.Remove(tutor);
            _context.SaveChanges();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorExists(int id)
        {
            return _context.Tutor.Count(e => e.id == id) > 0;
        }
    }
}