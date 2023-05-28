using DBMVCSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMVCConnection.Controllers
{
    public class EmployeeController : Controller
    {
        MVCSQLContext _DB;

        public EmployeeController(MVCSQLContext db)
        {
            _DB = db;
        }

        public IActionResult Index()
        {
            TblEmployee em = _DB.TblEmployees.FirstOrDefault();

            return View(em);
        }
    }
}
