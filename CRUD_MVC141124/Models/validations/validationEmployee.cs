using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC141124.Models.validations
{
    public class validationEmployee
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [nameValidationClass]
        public string name { get; set; }
        [Required]
        [Range(15000,30000)]
        public Nullable<decimal> salary { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Address in email format required")]
        public string Address { get; set; }
        [Required]
        [DataType(dataType:DataType.Text)]
        public Nullable<int> city { get; set; }
    }
}