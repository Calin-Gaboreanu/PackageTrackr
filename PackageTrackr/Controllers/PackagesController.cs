using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageTrackr;
using PackageTrackr.Models;
using PagedList;
using PagedList.Mvc;

namespace PackageTrackr.Controllers
{
    public class PackagesController : Controller
    {
        private PackageTrackrContext db = new PackageTrackrContext();

        // GET: Packages
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, string currentStatusFilter, string statusFilter, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["AWBSortParm"] = String.IsNullOrEmpty(sortOrder) ? "awb_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";
            ViewData["StatusSortParm"] = sortOrder == "status" ? "status_desc" : "status";

            var packages = db.Packages.Include(p => p.PackageStatus);

            var StatusLst = db.Packages.Select(p => p.PackageStatus.Name).Distinct();

            ViewData["statusFilter"] = new SelectList(StatusLst);

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (statusFilter == null)
                statusFilter = currentStatusFilter;

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatusFilter"] = statusFilter;

            //Sort
            switch(sortOrder)
            {
                case "awb_desc":
                    packages = packages.OrderByDescending(p => p.AWB);
                    break;
                case "date":
                    packages = packages.OrderBy(p => p.EnteredDate);
                    break;
                case "date_desc":
                    packages = packages.OrderByDescending(p => p.EnteredDate);
                    break;
                case "status":
                    packages = packages.OrderBy(p => p.PackageStatus.Name);
                    break;
                case "status_desc":
                    packages = packages.OrderByDescending(p => p.PackageStatus.Name);
                    break;
                default:
                    packages = packages.OrderBy(p => p.AWB);
                    break;
            }

            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                packages = packages.Where(p => p.AWB.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(statusFilter))
            {
                packages = packages.Where(p => p.PackageStatus.Name == statusFilter);
            }
            


            int pageSize = 5;
            int pageNumber = (page ?? 1);
            

            return View(packages.ToPagedList(pageNumber, pageSize));
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Packages/Create
        public ActionResult Create()
        {
            ViewBag.PackageStatusId = new SelectList(db.PackageStatuses, "Id", "Name");
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AWB,EnteredDate,PackageStatusId")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackageStatusId = new SelectList(db.PackageStatuses, "Id", "Name", package.PackageStatusId);
            return View(package);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackageStatusId = new SelectList(db.PackageStatuses, "Id", "Name", package.PackageStatusId);
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AWB,EnteredDate,PackageStatusId")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackageStatusId = new SelectList(db.PackageStatuses, "Id", "Name", package.PackageStatusId);
            return View(package);
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
            db.SaveChanges();
            return RedirectToAction("Index");
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
