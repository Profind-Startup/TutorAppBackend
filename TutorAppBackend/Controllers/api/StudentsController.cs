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
    public class StudentsController : BaseApiController
    {
        public StudentsController() : base() { }


        //GET: api/Student/5/User
        [Route("api/Student/{id}/User")]
        public User GetStudentUser(int studentid)
        {
            Student student = _context.Student.Find(studentid);
            if (student == null)
            {
                return null;
                //  return NotFound();
            }
            return _context.User.Where(x => x.id == studentid).FirstOrDefault();


        }
        //GET: api/Students/5/Reservations
        [Route("api/Students/{id}/Reservations")]
        public IQueryable<Reservation> GetStudentReservations(int id)
        {
            Student student = _context.Student.Find(id);
            if (student == null)
            {
                return null;
                //  return NotFound();
            }
            return _context.Reservation.Where(x => x.student_id == id);
        }

        // GET: api/Students
        public IQueryable<Student> GetStudent()
        {
            return _context.Student;
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Student.Add(student);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.id }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            _context.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Count(e => e.id == id) > 0;
        }
    }
}