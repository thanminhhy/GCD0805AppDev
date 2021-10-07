using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0805AppDev.ViewModels
{
    public class TeamUsersViewModel
    {
        public Team Team { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}