using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models.Test
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public List<TestUser> TestUsers { get; set; }


    }
}