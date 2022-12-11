using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrudApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = employee.Name,
                    City = employee.City,
                    State = employee.State,
                    Salary = employee.Salary
                };

                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "No empty fields plz";
                return View(employee);
            }
        }
        public IActionResult Index()
        {
            //int i = 1;
            var result = context.Employees.ToList();
            //foreach(var res in result)
            //{
            //    res.ShowId = i++; 
            //};

            return View(result);
        }

        public IActionResult Edit(int Id)
        {
            var emp = context.Employees.SingleOrDefault(a => a.Id == Id);
            var result = new Employee();
            if (ModelState.IsValid)
            {
                result.Id = emp.Id;
                result.Name = emp.Name;
                result.City = emp.City;
                result.State = emp.State;
                result.Salary = emp.Salary;
                return View(result);
            };

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var result = new Employee(); 
            if(ModelState.IsValid)
            {
                result.Id = employee.Id;
                result.Name = employee.Name;
                result.City = employee.City;
                result.State = employee.State;
                result.Salary = employee.Salary;
            }
            context.Employees.Update(result);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var emp = context.Employees.SingleOrDefault(a => a.Id == Id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
