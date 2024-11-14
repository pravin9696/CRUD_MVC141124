using CRUD_MVC141124.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC141124.Controllers
{
    public class DefaultController : Controller
    {
        private EmpDBEntities edbo = new EmpDBEntities();
        public ActionResult Index()
        {
            List<tblEmployee> emplist = edbo.tblEmployees.ToList();

            return View(emplist);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblEmployee e = edbo.tblEmployees.SingleOrDefault(x => x.ID == id);
            if (e!=null)
            {
                edbo.tblEmployees.Remove(e);
                int n = edbo.SaveChanges();
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
            tblEmployee e1 = edbo.tblEmployees.FirstOrDefault(x => x.ID == id);
            if (e1==null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(e1);
            }
        }
        [HttpPost]
        public ActionResult Edit(tblEmployee emp)
        {
            if (ModelState.IsValid)
            {
                tblEmployee oldemp = edbo.tblEmployees.FirstOrDefault(x => x.ID == emp.ID);
                oldemp.name = emp.name;
                oldemp.Address = emp.Address;
                oldemp.salary = emp.salary;
                oldemp.city = emp.city;
                int n = edbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            

        }
    }
}