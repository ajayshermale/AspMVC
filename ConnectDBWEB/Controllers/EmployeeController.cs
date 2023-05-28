using DBcon.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectDBWEB.Controllers
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
            var em = _DB.TblEmployees.FirstOrDefault();

            return View(em);
        }
    }
}
