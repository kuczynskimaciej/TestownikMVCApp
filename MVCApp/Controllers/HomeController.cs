using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestownikMVCApp.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Relations;

namespace TestownikMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DALContext _context;

        public HomeController(DALContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Testownik()
        {
            Random rnd = new Random();
            var countOfQuestions = _context.Questions.Count();
            var indexOfRandomQuestion = rnd.Next(countOfQuestions);

            var question = _context.Questions
                .Include("QuestionAnswers.Answer")
                .Where(y => y.Id == indexOfRandomQuestion + 1).ToList().First();

            var questionModel = new QuestionModel()
            {
                Question = question.Question,
                Answers = question.QuestionAnswers.Select(x => x.Answer).Select(ans => new AnswerModel()
                {
                    Answer = ans.Answer,
                    IsCorrect = ans.IsCorrect
                }).ToList()
            };

            return View(questionModel);
        }

        [HttpPost]
        public IActionResult CheckAnswers(QuestionModel model)
        {

            return View(model);
        }

        public IActionResult AddQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(AddQuestionModel model)
        {
            var question = new DAL.Entities.QuestionEntity
            {
                Question = model.Question

            };

            List<int> addedAns = new List<int>();
            
            foreach(var ans in model.Answers)
            {

                var answer = new DAL.Entities.AnswerEntity
                {
                    Answer = ans
                };
                _context.Answers.Add(answer);
                _context.SaveChanges();
                addedAns.Add(answer.Id);
            }


            _context.Questions.Add(question);

            _context.SaveChanges();

            foreach (var ans in addedAns)
            {
                _context.QuestionAnswers.Add(new QuestionAnswers()
                {
                    QuestionId = question.Id,
                    AnswerId = ans
                });

                _context.SaveChanges();
            }
  

            return View(model);
        }

        public IActionResult ShowQuestions()
        {
            var questions = _context.Questions
               .Include("QuestionAnswers.Answer").ToList();

            var questionsModel = questions.Select(que =>
            {
                var a = que.QuestionAnswers.Select(y => y.Answer);
                return new QuestionModel()
                {
                    Id = que.Id,
                    Question = que.Question,
                    Answers = a != null && a.Any() ? a.Select(ans => new AnswerModel()
                    {
                        Answer = ans.Answer,
                        IsCorrect = ans.IsCorrect,

                    }).ToList() : new List<AnswerModel>()
                };
            }).ToList();

            return View(questionsModel);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
