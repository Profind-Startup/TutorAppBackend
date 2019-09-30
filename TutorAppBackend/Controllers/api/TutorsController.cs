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