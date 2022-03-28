using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Maintenance.Utils.CustomAttributes
{
    public class EdadminimaAttribute : ValidationAttribute
    {
        //public int EdadMinima { get; set; }

        //public EdadminimaAttribute(int M) : base("{0} has to many words.")
        //{
        //    EdadMinima = M;
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //if (value != null)
            //    if ((int)value > 5)
            //    {
            //        return ValidationResult.Success;
            //    }

            //var errorMessage = FormatErrorMessage((validationContext.DisplayName));
            var result = new ValidationResult("Sorry you are not old enough");
            return result;
        }
    }
}