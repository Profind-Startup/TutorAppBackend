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
    public class PaymentsController : BaseApiController
    {
        public PaymentsController() : base() { }

        // GET: api/Payments
        public IQueryable<Payment> GetPayment()
        {
            return _context.Payment;
        }

        // GET: api/Payments/5
        [ResponseType(typeof(Payment))]
        public IHttpActionResult GetPayment(int id)
        {
            var payment = _context.Payment.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // PUT: api/Payments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPayment(int id, Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.id)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        [ResponseType(typeof(Payment))]
        public IHttpActionResult PostPayment(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Payment.Add(payment);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payment.id }, payment);
        }

        // DELETE: api/Payments/5
        [ResponseType(typeof(Payment))]
        public IHttpActionResult DeletePayment(int id)
        {
            var payment = _context.Payment.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(payment);
            _context.SaveChanges();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Count(e => e.id == id) > 0;
        }
    }
}