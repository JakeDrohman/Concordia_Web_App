using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Student_Address
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Street Address")]
        public string Street_Address { get; set; }

        public string Apartment { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zipcode { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }
    }
}