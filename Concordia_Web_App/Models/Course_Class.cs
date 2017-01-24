using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Course_Class
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Professor")]
        public string Professor_Id { get; set; }
        public ApplicationUser Professor { get; set; }

        [DisplayName("Alternate Professor")]
        [ForeignKey("Alt_Professor")]
        public string Alt_Professor_Id { get; set; }
        public ApplicationUser Alt_Professor { get; set; }
    }
}