using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public int ShowId { get; set; }

        
        [Required(ErrorMessage = "Cannot be blank")]
        public string Name { get; set; }

        
        [Required(ErrorMessage = "Cannot be blank")]
        public string City { get; set; }


        [Required(ErrorMessage = "Cannot be blank")]
        public string State { get; set; }
        
        
        [Required(ErrorMessage = "Cannot be blank")]
        public string Salary { get; set; }
    }
}