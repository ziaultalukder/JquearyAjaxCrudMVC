using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;
using WebApplication7.ViewModel;

namespace WebApplication7.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult loaddata()
        {
            var department = db.Departments.Where(c => c.IsDeleted == false).ToList();
            return Json(new { data = department }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            var department = db.Departments.Where(c => c.IsActive == false && c.IsDeleted == false).ToList();
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(DepartmentViewModel departmentViewModel)
        {
            var department = new Department
            {
                Name = departmentViewModel.Name,
                IsActive = departmentViewModel.IsActive,
                IsDeleted = departmentViewModel.IsDeleted
            };
            db.Departments.Add(department);
            db.SaveChanges();
            return Json(data: "Save Successfully", behavior: JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteDepartment(int id)
        {
            if (id == null)
            {
                return Json(data: "Not Deleted", behavior: JsonRequestBehavior.AllowGet);
            }
            var department = db.Departments.FirstOrDefault(c => c.Id == id);
            db.Entry(department).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(data: "Deleted Successfully", behavior: JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditDepartment(int id)
        {
            if (id == null)
            {
                return null;
            }
            var school = db.Departments.FirstOrDefault(c => c.Id == id);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(school, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateDepartment(DepartmentViewModel departmentViewModel)
        {
            var department = new Department
            {
                Id = departmentViewModel.Id,
                IsActive = departmentViewModel.IsActive,
                IsDeleted = departmentViewModel.IsDeleted,
                Name = departmentViewModel.Name
            };
            db.Entry(department).State = EntityState.Modified;
            db.SaveChanges();
            return Json(data: "Updated Successfully", behavior: JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(DepartmentViewModel departmentViewModel)
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
