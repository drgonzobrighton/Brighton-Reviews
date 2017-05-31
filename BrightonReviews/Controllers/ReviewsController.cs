using BrightonReviews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BrightonReviews.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index([Bind(Prefix = "id")] int venueId)
        {
            var venue = db.Venues.Where(x => x.Id == venueId)
                        .Select(r => new VenueViewModel
                        {
                            Id = r.Id,
                            Address = r.Address,
                            AvarageScore = r.Reviews.Average(review => review.Rating),
                            Description = r.Description,
                            ImgURL = r.ImgURL,
                            Name = r.Name,
                            ReviewCount = r.Reviews.Count(),
                            Reviews = r.Reviews,
                            VenueType = r.VenueType,
                            VenueTypeId = r.VenueTypeId
                        }).First();
           
            if (venue != null)
            {
                return View(venue);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int venueId)
        {
           // ViewBag.VenueId = venueId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = review.VenueId });
            }
            return View(review);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var review = db.Reviews.Find(id);

            if (review == null)
            {
                return HttpNotFound();
            }
           
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",  new { id = review.VenueId });
            }
            ViewBag.VenueId = review.VenueId;
            return View(review);
        }

        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = db.Reviews.Find(id);
            ViewBag.VenueId = review.VenueId;

            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id); Venue venue = db.Venues.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index", new {id = review.VenueId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}