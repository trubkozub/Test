using System.Collections.Generic;

namespace Registration.ModelView
{
    public class TestResult
    {
        public int TestUserNumber { set; get; }
        public List<int> AnswerCorrect { set; get; }
        public List<int> AnswerUnCorrect { set; get; }

        public int QuestionCount { get; }

        public TestResult (int number, List<int> correct, List<int> unCorrect)
        {
            TestUserNumber = number;
            AnswerCorrect = correct;
            AnswerUnCorrect = unCorrect;
            QuestionCount = correct.Count + unCorrect.Count;
        }
    }
}