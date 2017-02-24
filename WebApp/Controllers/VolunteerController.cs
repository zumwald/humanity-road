namespace WebApp.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Security.Claims;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Mvc;
    using DAL;
    using Utilities;

    [RequireHttps(Order = 0)]
    [System.Web.Mvc.Authorize(Order = 1)]
    public class VolunteerController : ApiController
    {
        private DataContext db = new DataContext();
        
        // GET: api/Volunteers
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult Get()
        {
            var id = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_ID_K);
            Volunteer volunteer = db.Volunteers.FirstOrDefault(v => v.Id.Equals(id, StringComparison.InvariantCulture));
            if (volunteer == null)
            {
                // create the volunteer
                return this.PostVolunteer(new Volunteer());
            }

            return Ok(volunteer);
        }

        // PUT: api/Volunteers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVolunteer(Volunteer volunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!this.VolunteerExists(volunteer.Id))
            {
                return BadRequest();
            }

            db.Entry(volunteer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.VolunteerExists(volunteer.Id))
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

        // POST: api/Volunteers
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult PostVolunteer(Volunteer volunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Volunteers.Add(volunteer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VolunteerExists(volunteer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = volunteer.Id }, volunteer);
        }

        ////// DELETE: api/Volunteers/5
        ////[ResponseType(typeof(Volunteer))]
        ////public IHttpActionResult DeleteVolunteer(string id)
        ////{
        ////    Volunteer volunteer = db.Volunteers.Find(id);
        ////    if (volunteer == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    db.Volunteers.Remove(volunteer);
        ////    db.SaveChanges();

        ////    return Ok(volunteer);
        ////}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VolunteerExists(string id)
        {
            return db.Volunteers.Count(e => e.Id == id) > 0;
        }
    }
}