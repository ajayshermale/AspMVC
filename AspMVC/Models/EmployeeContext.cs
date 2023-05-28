using Microsoft.EntityFrameworkCore;

namespace ASPMVC.Models
{
    public class EmployeeContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; } 

    }
}
