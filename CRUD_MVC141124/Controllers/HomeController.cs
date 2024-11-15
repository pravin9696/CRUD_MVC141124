using CRUD_MVC141124.Models;
using CRUD_MVC141124.Models.validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC141124.Controllers
{
    public class HomeController : Controller
    {
        private EmpDBEntities dbo = new EmpDBEntities();
        public ActionResult Index()
        {
            List<tblEmployee> employees = dbo.tblEmployees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(validationEmployee ve)
        {
            if (ModelState.IsValid)
            {
                tblEmployee temp = new tblEmployee();
                temp.ID = ve.ID;
                temp.name = ve.name;
                temp.Address = ve.Address;
                temp.salary = ve.salary;
                temp.city = ve.city;
                dbo.tblEmployees.Add(temp);
                int n = dbo.SaveChanges();
                if (n>0)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = dbo.tblEmployees.Find(id);
            validationEmployee vemp = new validationEmployee();
            vemp.ID = emp.ID;
            vemp.name = emp.name;
            vemp.Address = emp.Address;
            vemp.salary = emp.salary;
            vemp.city = emp.city;
            return View(vemp);
        }
        [HttpPost]
        public ActionResult Edit(validationEmployee ve)
        {
            if (ModelState.IsValid)
            {
            var emp = dbo.tblEmployees.FirstOrDefault(x => x.ID == ve.ID);            

            emp.name = ve.name;
            emp.Address = ve.Address;
            emp.salary = ve.salary;
            emp.city = ve.city;
                int n = dbo.SaveChanges();
                if (n>0)
                {
                    return RedirectToAction("index");
                }

            }
            return View();
        }
    }
}