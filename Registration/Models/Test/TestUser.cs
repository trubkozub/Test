using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models.Test
{
    public class TestUser
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public List<Question> Questions { get; set; }

    }
}