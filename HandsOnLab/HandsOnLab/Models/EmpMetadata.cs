using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HandsOnLab.Validators;

namespace HandsOnLab.Models
{
    public class EmpMetadata
    {
        [Required(ErrorMessage ="No is Required")]
        //[HOLCustomValidator(ErrorMessage = "")]
        public int No { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [HOLCustomValidator(ErrorMessage = "Name is Invalid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
    }
}