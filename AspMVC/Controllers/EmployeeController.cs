using ASPMVC.Models;
using DBfirst.Entity;
using Microsoft.AspNetCore.Mvc;


namespace ASPMVC.Controllers
{
    public class EmployeeController : Controller
    {
        MVCSQLContext _employeeContext;
         
        public EmployeeController(MVCSQLContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public IActionResult Index()
        {
            //Employee employee = new Employee()
            //{
            //    EmployeeID = 11,
            //    City ="Mumbai",
            //    Gender="Male",
            //    Name="Ajay B shermale"

            //};

            //DBfirst.Entity.Employee employee = _employeeContext.TblEmployees.Single(emp => emp.EmployeeId == 1);
            DBfirst.Entity.TblEmployee employee = (from emp in _employeeContext.TblEmployees where emp.EmployeeId == 1 select emp).FirstOrDefault();   

            return View(employee);
        }
    }
}
