using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Registration.Models
{
    public class User : IdentityUser
    {
        public int Grade { get; set; }
        public User()
        {
        }
    }
}