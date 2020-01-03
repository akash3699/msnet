using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HandsOnLab.Validators
{
    public class HOLCustomValidator:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value.ToString()!="1234")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}