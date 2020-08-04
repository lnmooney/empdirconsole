using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreApp
{ 
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jobTitle { get; set; }
    }
}