using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrightonReviews.Models;

namespace BrightonReviews.Controllers
{
    public class VenuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Venues
        public ActionResult Index(string orderBy, string searchString)
        {

            ViewBag.Category = "All Venues";

            if (orderBy == "AvarageRate")
            {
                var venues = from r in db.Venues
                             orderby r.Reviews.Average(rv => rv.Rating) descending
                             select new VenueViewModel
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
                             };

                if (!String.IsNullOrEmpty(searchString))
                {
                    venues = venues.Where(x => x.Name.Contains(searchString));
                }

                return View(venues);
            }
            else if (orderBy == "NrOfReviews")
            {
                var venues = from r in db.Venues
                             orderby r.Reviews.Count descending
                             select new VenueViewModel
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

                             };

                if (!String.IsNullOrEmpty(searchString))
                {
                    venues = venues.Where(x => x.Name.Contains(searchString));
                }

                return View(venues);
            }
            else //order by name
            {
                var venues = from r in db.Venues
                             orderby r.Name ascending
                             select new VenueViewModel
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
                             };
                if (!String.IsNullOrEmpty(searchString))
                {
                    venues = venues.Where(x => x.Name.Contains(searchString));
                }

                return View(venues);
            }
        }

        public ActionResult AutoComplete(string term)
        {
            var venue = from v in db.Venues
                        where v.Name.Contains(term)
                        select new { label = v.Name };

            return Json(venue, JsonRequestBehavior.AllowGet);
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venue venue = db.Venues.Find(id);

            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }


        public ActionResult Create()
        {
            ViewBag.VenueTypeId = new SelectList(db.VenueTypes, "Id", "Cathegory");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Venues.Add(venue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VenueTypeId = new SelectList(db.VenueTypes, "Id", "Cathegory", venue.VenueTypeId);
            return View(venue);
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueTypeId = new SelectList(db.VenueTypes, "Id", "Cathegory", venue.VenueTypeId);
            return View(venue);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Reviews", new { id = venue.Id });
            }
            ViewBag.VenueTypeId = new SelectList(db.VenueTypes, "Id", "Cathegory", venue.VenueTypeId);
            return View(venue);
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.SingleOrDefault(x => x.Id == id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venue venue = db.Venues.Find(id);
            db.Venues.Remove(venue);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Restaurants(string orderBy)
        {
            ViewBag.Category = "Restaurants";

            if (orderBy == "AvarageRate")
            {
                var venues = from r in db.Venues
                             where r.VenueTypeId == 1
                             orderby r.Reviews.Average(review => review.Rating) descending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }
            else if (orderBy == "NrOfReviews")
            {

                var venues = from r in db.Venues
                             where r.VenueTypeId == 1
                             orderby r.Reviews.Count descending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }
            else
            {
                var venues = from r in db.Venues
                             where r.VenueTypeId == 1
                             orderby r.Name ascending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }

        }

        public ActionResult Pubs(string orderBy)
        {
            ViewBag.Category = "Pubs";

            if (orderBy == "AvarageRate")
            {
                var venues = from r in db.Venues
                             where r.VenueTypeId == 3
                             orderby r.Reviews.Average(review => review.Rating) descending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }
            else if (orderBy == "NrOfReviews")
            {

                var venues = from r in db.Venues
                             where r.VenueTypeId == 3
                             orderby r.Reviews.Count descending
                             select new VenueViewModel
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

                             };


                return View(venues);
            }
            else
            {
                var venues = from r in db.Venues
                             where r.VenueTypeId == 3
                             orderby r.Name ascending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }

        }

        public ActionResult Hotels(string orderBy)
        {
            ViewBag.Category = "Hotels";

            if (orderBy == "AvarageRate")
            {
                var venues = from r in db.Venues
                             where r.VenueTypeId == 2
                             orderby r.Reviews.Average(review => review.Rating) descending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }
            else if (orderBy == "NrOfReviews")
            {

                var venues = from r in db.Venues
                             where r.VenueTypeId == 2
                             orderby r.Reviews.Count descending
                             select new VenueViewModel
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

                             };


                return View(venues);
            }
            else
            {
                var venues = from r in db.Venues
                             where r.VenueTypeId == 2
                             orderby r.Name ascending
                             select new VenueViewModel
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

                             };

                return View(venues);
            }

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
