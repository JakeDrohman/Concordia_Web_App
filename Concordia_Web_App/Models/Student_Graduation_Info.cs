using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Student_Graduation_Info
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Credits Needed To Graduate")]
        public float Credits_Needed { get; set; }

        [DisplayName("Credits Completed")]
        public float Credits_Completed { get; set; }

        public string Track { get; set; }

        public bool Withdrawn { get; set; }

        public bool Graduated { get; set; }

        public bool Dismissed { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }
    }
}