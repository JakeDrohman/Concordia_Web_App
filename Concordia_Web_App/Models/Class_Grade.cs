using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Class_Grade
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Grade Percentage")]
        public decimal Grade_Percentage { get; set; }

        public bool Passed { get; set; }

        public bool Failed { get; set; }
    }
}