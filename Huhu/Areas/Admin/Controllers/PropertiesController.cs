﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Huhu.Areas.Admin.Controllers.MiddleWare;
using Huhu.Models;

namespace Huhu.Areas.Admin.Controllers
{


    [LoginVerification]
    public class PropertiesController : Controller
    {
        private AD25Team26Entities db = new AD25Team26Entities();

        // GET: Admin/Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.District).Include(p => p.Property_Status).Include(p => p.Property_Type);
            return View(properties.ToList());
        }

        // GET: Admin/Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Admin/Properties/Create
        public ActionResult Create()
        {
            ViewBag.District_ID = new SelectList(db.Districts, "ID", "District_Name");
            ViewBag.Property_Status_ID = new SelectList(db.Property_Status, "ID", "Property_Status_Name");
            ViewBag.Property_Type_ID = new SelectList(db.Property_Type, "ID", "Property_Type_Name");
            return View();
        }

        // POST: Admin/Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Property_Code,Property_Name,Property_Type_ID,Description,District_ID,Address,Area,Bed_Room,Bath_Room,Price,Installment_Rate,Avatar,Album,Property_Status_ID")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District_ID = new SelectList(db.Districts, "ID", "District_Name", property.District_ID);
            ViewBag.Property_Status_ID = new SelectList(db.Property_Status, "ID", "Property_Status_Name", property.Property_Status_ID);
            ViewBag.Property_Type_ID = new SelectList(db.Property_Type, "ID", "Property_Type_Name", property.Property_Type_ID);
            return View(property);
        }

        // GET: Admin/Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.District_ID = new SelectList(db.Districts, "ID", "District_Name", property.District_ID);
            ViewBag.Property_Status_ID = new SelectList(db.Property_Status, "ID", "Property_Status_Name", property.Property_Status_ID);
            ViewBag.Property_Type_ID = new SelectList(db.Property_Type, "ID", "Property_Type_Name", property.Property_Type_ID);
            return View(property);
        }

        // POST: Admin/Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Property_Code,Property_Name,Property_Type_ID,Description,District_ID,Address,Area,Bed_Room,Bath_Room,Price,Installment_Rate,Avatar,Album,Property_Status_ID")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District_ID = new SelectList(db.Districts, "ID", "District_Name", property.District_ID);
            ViewBag.Property_Status_ID = new SelectList(db.Property_Status, "ID", "Property_Status_Name", property.Property_Status_ID);
            ViewBag.Property_Type_ID = new SelectList(db.Property_Type, "ID", "Property_Type_Name", property.Property_Type_ID);
            return View(property);
        }

        // GET: Admin/Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Admin/Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
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
