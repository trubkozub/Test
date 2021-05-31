using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Registration.Models.Test
{
    public class Answer
    {
        public int Id { set; get; }

        public bool Correct { set; get; }
        public string Text { set; get; }

        public Question Question { get; set; }
    }
}