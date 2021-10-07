using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0805AppDev.ViewModels
{
    public class UserTeamsViewModel
    {
        public int TeamId { get; set; }
        public List<Team> Teams { get; set; }
        public string UserId { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}