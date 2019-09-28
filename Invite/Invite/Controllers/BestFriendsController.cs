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
using Invite.Models;

namespace Invite.Controllers
{
    public class BestFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/BestFriends
        public IQueryable<BestFriends> GetBestFriends()
        {
            return db.BestFriends;
        }

        // GET: api/BestFriends/5
        [ResponseType(typeof(BestFriends))]
        public IHttpActionResult GetBestFriends(int id)
        {
            BestFriends bestFriends = db.BestFriends.Find(id);
            if (bestFriends == null)
            {
                return NotFound();
            }

            return Ok(bestFriends);
        }

        // PUT: api/BestFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBestFriends(int id, BestFriends bestFriends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bestFriends.FriendID)
            {
                return BadRequest();
            }

            db.Entry(bestFriends).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestFriendsExists(id))
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

        // POST: api/BestFriends
        [ResponseType(typeof(BestFriends))]
        public IHttpActionResult PostBestFriends(BestFriends bestFriends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BestFriends.Add(bestFriends);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bestFriends.FriendID }, bestFriends);
        }

        // DELETE: api/BestFriends/5
        [ResponseType(typeof(BestFriends))]
        public IHttpActionResult DeleteBestFriends(int id)
        {
            BestFriends bestFriends = db.BestFriends.Find(id);
            if (bestFriends == null)
            {
                return NotFound();
            }

            db.BestFriends.Remove(bestFriends);
            db.SaveChanges();

            return Ok(bestFriends);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BestFriendsExists(int id)
        {
            return db.BestFriends.Count(e => e.FriendID == id) > 0;
        }
    }
}