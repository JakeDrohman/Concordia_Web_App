using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Course Name")]
        public string Course_Name { get; set; }

        public float Credits { get; set; }
    }
}