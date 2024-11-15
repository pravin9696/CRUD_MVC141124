using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_MVC141124.Models.validations
{
    public class nameValidationClass : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                //string name=(string)value;
                string name = value.ToString();
                if (name.Contains("Mr.")|| name.Contains("Ms."))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Name must contain Mr. or Ms."); 
            
        }
    }
}