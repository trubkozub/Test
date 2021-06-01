using Registration.Models.Test;
using Registration.ModelView;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Registration.Models;

namespace Registration.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        TestContext context = new TestContext();

        int questionPartCount = 2;

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Index()
        {
            Models.User userLogin = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<UserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Models.Test.User user = new Models.Test.User() { Password = userLogin.Id, Name = userLogin.UserName };
            context.Users.Add(user);
            context.SaveChanges();

            Models.Test.User userLast = context.Users.Where(x => x.Password == userLogin.Id).OrderByDescending(p => p.Id).FirstOrDefault();

            TestUser testUser = new TestUser() { UserId = userLast.Id};
            context.TestUsers.Add(testUser);
            context.SaveChanges();

            var questions = context.Questions.Include(a => a.Answers).Take(questionPartCount);
           
            testUser.Questions = questions.ToList(); ;

            return View(testUser);
        }

        [HttpPost]
        public ActionResult Index(TestUser testPart)
        {
            if (testPart.Questions != null)
            {
                foreach (Question question in testPart.Questions)
                {
                    UserAnswer userAnswer = new UserAnswer
                    {
                        TestUserId = testPart.Id,
                        QuestionId = question.Id,
                        AnswerId = Convert.ToInt32(question.SelectedAnswer),
                    };
                    context.UserAnswers.Add(userAnswer);
                }
                context.SaveChanges();
            }

            int questionLast = context.Questions.OrderByDescending(p => p.Id).FirstOrDefault().Id;
            int lastQuestionPart = testPart.Questions.Last().Id;

            if (lastQuestionPart < questionLast)
            {
                var questions = context.Questions.Where(q => q.Id > lastQuestionPart).Take(questionPartCount).Include(a => a.Answers);

                TestUser model = context.TestUsers.Where(x => x.Id == testPart.Id).FirstOrDefault();
                model.Questions = questions.ToList();
                return View(model);
            }
            else
                return RedirectToAction("Result", new { userTestNumber = testPart.Id });
        }

        public ActionResult Result(int userTestNumber)
        {
            var userAnswers = context.UserAnswers.Where(a => a.TestUserId == userTestNumber).Select(a => a.AnswerId).ToList();
            var answersCorrect = context.Answers.Where(x => x.Correct == true).Select(a => a.Id).ToList();

            var resultUnCorrect = userAnswers.Except(answersCorrect).ToList();
            var resultCorrect = userAnswers.Intersect(answersCorrect).ToList();
            TestResult testResult = new TestResult(userTestNumber, resultCorrect, resultUnCorrect);
            return View(testResult);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
