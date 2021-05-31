using System.Collections.Generic;


namespace Registration.Models.Test
{
    public class Question
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public string SelectedAnswer { set; get; }
        public List<Answer> Answers { get; set; }
    }
}