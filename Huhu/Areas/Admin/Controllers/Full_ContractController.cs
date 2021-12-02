using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Huhu.Models;

namespace Huhu.Areas.Admin.Controllers
{
    public class Full_ContractController : Controller
    {
        private AD25Team26Entities db = new AD25Team26Entities();

        // GET: Admin/Full_Contract
        public ActionResult Index()
        {
            var full_Contract = db.Full_Contract.Include(f => f.Property);
            return View(full_Contract.ToList());
        }

        public ActionResult PrintFullConTrac(int id)
        {

            var printData = db.Full_Contract.FirstOrDefault(x=> x.ID == id);
            return View(printData);
        }

        // GET: Admin/Full_Contract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Full_Contract full_Contract = db.Full_Contract.Find(id);
            if (full_Contract == null)
            {
                return HttpNotFound();
            }
            return View(full_Contract);
        }

        // GET: Admin/Full_Contract/Create
        public ActionResult Create()
        {
            ViewBag.Property_ID = new SelectList(db.Properties, "ID", "Property_Code");
            return View();
        }

        // POST: Admin/Full_Contract/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Full_Contract_Code,Customer_Name,Year_Of_Birth,SSN,Customer_Address,Mobile,Property_ID,Date_Of_Contract,Price,Deposit,Remain,Status")] Full_Contract full_Contract)
        {
            if (ModelState.IsValid)
            {
                db.Full_Contract.Add(full_Contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Property_ID = new SelectList(db.Properties, "ID", "Property_Code", full_Contract.Property_ID);
            return View(full_Contract);
        }

        // GET: Admin/Full_Contract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Full_Contract full_Contract = db.Full_Contract.Find(id);
            if (full_Contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.Property_ID = new SelectList(db.Properties, "ID", "Property_Code", full_Contract.Property_ID);
            return View(full_Contract);
        }

        // POST: Admin/Full_Contract/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Full_Contract_Code,Customer_Name,Year_Of_Birth,SSN,Customer_Address,Mobile,Property_ID,Date_Of_Contract,Price,Deposit,Remain,Status")] Full_Contract full_Contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(full_Contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Property_ID = new SelectList(db.Properties, "ID", "Property_Code", full_Contract.Property_ID);
            return View(full_Contract);
        }

        // GET: Admin/Full_Contract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Full_Contract full_Contract = db.Full_Contract.Find(id);
            if (full_Contract == null)
            {
                return HttpNotFound();
            }
            return View(full_Contract);
        }

        // POST: Admin/Full_Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Full_Contract full_Contract = db.Full_Contract.Find(id);
            db.Full_Contract.Remove(full_Contract);
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
