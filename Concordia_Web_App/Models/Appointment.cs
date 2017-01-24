using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Advisor")]
        public string Advisor_Id { get; set; }
        public ApplicationUser Advisor { get; set; }

        [DisplayName("Reason for Appointment")]
        public string Reason_For_Appointment { get; set; }

        public DateTime Date { get; set; }
    }
}