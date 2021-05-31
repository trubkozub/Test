using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.Models.Test
{
    public class UserAnswer
    {
        public int Id { get; set; }

        public int TestUserId { get; set; }

        public int QuestionId {  get; set; }

        public int AnswerId { get; set; }
    }
}