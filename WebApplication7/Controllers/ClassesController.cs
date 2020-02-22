using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class ClassesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Classes/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Classes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Classes/Create
        public ActionResult Create()
        {
            var department = db.Departments.Where(c => c.IsActive == false && c.IsDeleted == false).ToList();
            return View(department);
        }

        //
        // POST: /Classes/Create
        [HttpPost]
        public ActionResult Create(Classes classes)
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
        // GET: /Classes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Classes/Edit/5
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
        // GET: /Classes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Classes/Delete/5
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
