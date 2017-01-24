using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Student_Classes
    {
        [DisplayName("Class")]
        [ForeignKey("Course_Class")]
        public int Course_Class_Id { get; set; }
        public Course_Class Course_Class { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }

        [DisplayName("Class Grade")]
        [ForeignKey("Class_Grade")]
        public int Class_Grade_Id { get; set; }
        public Class_Grade Class_Grade { get; set; }
    }
}