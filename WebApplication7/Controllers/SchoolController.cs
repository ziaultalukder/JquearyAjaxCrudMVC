using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class SchoolController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext(); 
        //
        // GET: /Department/
        public ActionResult Index()
        {
            var school = db.School.Where(c => c.IsActive == false && c.IsDeleted == false).ToList();
            return View(school);
        }

        public JsonResult loaddata()
        {
            var school = db.School.Where(c => c.IsActive == false && c.IsDeleted == false).ToList();
            return Json(new { data = school }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveSchool(School school)
        {
            db.School.Add(school);
            db.SaveChanges();
            return Json(data: "Save Successfully", behavior: JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateSchool(School school)
        {
            db.Entry(school).State = EntityState.Modified;
            db.SaveChanges();
            return Json(data: "Updated Successfully", behavior: JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditSchool(int id)
        {
            if (id == null)
            {
                return null;
            }
            var school = db.School.FirstOrDefault(c => c.Id == id);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(school, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSchool(int id)
        {
            if (id == null)
            {
                return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
            }
            var school = db.School.FirstOrDefault(c => c.Id == id);
            db.Entry(school).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(data: "Deleted Successfully", behavior: JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Department/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Department/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Department/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
