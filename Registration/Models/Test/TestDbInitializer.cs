using System.Collections.Generic;
using System.Data.Entity;


namespace Registration.Models.Test
{
    public class TestDbInitializer : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            User user = new User() { Name = "Bill"};

            List<Answer> answers = new List<Answer>()
            {
                new Answer { Text ="32 кпк", Correct = true },
                new Answer { Text ="37 кпк" },
                new Answer { Text ="47 кпк" },
                new Answer { Text ="8 кпк" },

                new Answer { Text ="Венера", Correct = true  },
                new Answer { Text ="Меркурий" },
                new Answer { Text ="Солнце" },
                new Answer { Text ="Земля" },

                new Answer { Text ="Меркурии", Correct = true  },
                new Answer { Text ="Земле" },
                new Answer { Text ="Венере" },
              
            };

            foreach (Answer answer in answers)
                context.Answers.Add(answer);
           

            List<Question> questions = new List<Question>()
            {
                new Question {
                    Text ="Галактика удаляется от нас со скоростью 6000 км/с. Если она имеет видимый угловой размер 2′, то ее линейные размеры составляют:",
                    Answers = answers.GetRange(0, 4)},
                new Question { Text ="Самой яркой на небе планетой является:",
                    Answers = answers.GetRange(4, 4)},
                new Question { Text ="Крупнейшие горы в Солнечной системе находятся на:",
                    Answers = answers.GetRange(8, 3)},
            };

            foreach (Question question in questions)
                context.Questions.Add(question);

            base.Seed(context);
        }
    }
}