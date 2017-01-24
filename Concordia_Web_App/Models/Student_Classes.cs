using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Student_Classes
    {
        [Key, Column(Order = 0)]
        [DisplayName("Class")]
        [ForeignKey("Course_Class")]
        public int Course_Class_Id { get; set; }
        public Course_Class Course_Class { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("Class Grade")]
        [ForeignKey("Class_Grade")]
        public int Class_Grade_Id { get; set; }
        public Class_Grade Class_Grade { get; set; }
    }
}