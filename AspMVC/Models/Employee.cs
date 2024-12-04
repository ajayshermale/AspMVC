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
        public string Region { get; set; }

        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }
    }
}
