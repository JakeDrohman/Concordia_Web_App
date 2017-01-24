using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concordia_Web_App.Models
{
    public class Assign_Roles_View_Model
    {
        public List<string> Role { get; set; }
        public ApplicationUser User { get; set; }
        public User_Information Info { get; set; }
    }
}