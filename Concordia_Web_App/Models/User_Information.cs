using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class User_Information
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }

        [DisplayName("First Name")]
        public string First_Name { get; set; }

        [DisplayName("Last Name")]
        public string Last_Name { get; set; }

        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DisplayName("Middle Initial")]
        public string Middle_Initial { get; set; }

        [DisplayName("Alternate First Name")]
        public string Alt_First_Name { get; set; }

        [DisplayName("Alternate Last Name")]
        public string Alt_Last_Name { get; set; }

        [DisplayName("Alternate Middle Initial")]
        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Alt_Middle_Initial { get; set; }
    }
}