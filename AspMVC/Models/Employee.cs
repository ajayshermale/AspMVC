using System.ComponentModel.DataAnnotations.Schema;

namespace ASPMVC.Models
{
    [Table("TblEmployee")]
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
         public string Address {get;set;}

    }
}
