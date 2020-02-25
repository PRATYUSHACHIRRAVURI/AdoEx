using AdoEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoEx.Controllers
{
    public class UserController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // GET: Student/Create
        public ActionResult Create(Models.User s)
        {

         
                // TODO: Add insert logic here
                User s1 = new User();
                s1.InsertRegDetails(s);

                // return View();
                return RedirectToAction("Prints");
           
        }
        public ActionResult Prints()
        {
            User s2 = new User();
            s2.ViewRegistrations();
            return View();
        }
        // POST: Student/Create


            // GET: Student/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
