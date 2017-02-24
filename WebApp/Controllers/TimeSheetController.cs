namespace WebApp.Controllers
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Http;
    using System.Web.Http.Description;
    using WebApp;
    using DAL;
    using Utilities;

    public class TimeSheetController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/TimeSheet
        public IQueryable<TimeSheet> GetTimeSheets()
        {
            // get the currently signed-in user's id
            var id = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_ID_K);

            // return only the timesheets which belong to the currently signed-in user
            return db.TimeSheets.Where(t => t.volunteerId.Equals(id, StringComparison.InvariantCulture));
        }

        //// GET: api/TimeSheet/5
        //[ResponseType(typeof(TimeSheet))]
        //public IHttpActionResult GetTimeSheet(Guid id)
        //{
        //    TimeSheet timeSheet = db.TimeSheets.Find(id);
        //    if (timeSheet == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(timeSheet);
        //}

        //// PUT: api/TimeSheet/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTimeSheet(Guid id, TimeSheet timeSheet)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != timeSheet.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(timeSheet).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TimeSheetExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/TimeSheet
        [ResponseType(typeof(TimeSheet))]
        public IHttpActionResult PostTimeSheet(TimeSheet timeSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // go ahead and lookup the currently signed-in user and add them to this timesheet
            var id = ClaimsPrincipal.Current.GetUserProperty(IdentityHelpers.PERSON_ID_K);
            timeSheet.volunteerId = id;

            db.TimeSheets.Add(timeSheet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeSheet.Id }, timeSheet);
        }

        // DELETE: api/TimeSheet/5
        [ResponseType(typeof(TimeSheet))]
        public IHttpActionResult DeleteTimeSheet(Guid id)
        {
            TimeSheet timeSheet = db.TimeSheets.Find(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            db.TimeSheets.Remove(timeSheet);
            db.SaveChanges();

            return Ok(timeSheet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeSheetExists(Guid id)
        {
            return db.TimeSheets.Count(e => e.Id == id) > 0;
        }
    }
}