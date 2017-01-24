using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string First_Name { get; set; }

        [DisplayName("Last Name")]
        public string Last_Name { get; set; }

        [DisplayName("Middle Initial")]
        public char Middle_Initial { get; set; }

        [DisplayName("Alternate First Name")]
        public string Alt_First_Name { get; set; }

        [DisplayName("Alternate Last Name")]
        public string Alt_Last_Name { get; set; }

        [DisplayName("Alternate Middle Initial")]
        public char Alt_Middle_Initial { get; set; }

        [ForeignKey("Advisor")]
        public string Advisor_Id { get; set; }
        public ApplicationUser Advisor { get; set; }
    }
}