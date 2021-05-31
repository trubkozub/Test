using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Registration.Models.Test
{
    public class TestContext : DbContext
    {

        public TestContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserAnswer> UserAnswers { get; set; }


    }
}