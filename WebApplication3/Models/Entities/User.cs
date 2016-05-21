using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address{ get; set; }
        public string Email { get; set; }

    }
}