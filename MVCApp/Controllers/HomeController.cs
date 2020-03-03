using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestownikMVCApp.Models;
using DAL;
using Microsoft.EntityFrameworkCore;

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
                .Include(x => x.Answers)
                .Where(y => y.Id == indexOfRandomQuestion + 1).ToList().First();

            var questionModel = new QuestionModel()
            {
                Question = question.Question,
                Answers = question.Answers.Select(ans => new AnswerModel()
                {
                    Answer = ans.Answer,
                    IsCorrect = ans.IsCorrect,
                    SelectedAnswers = ans.SelectedAnswer
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
        public IActionResult AddQuestion(QuestionModel model)
        {
            var question = new DAL.Entities.QuestionEntity()
            {
                Question = model.Question
            };

            _context.Questions.Add(question);
            _context.SaveChanges();
            return View(model);
        }

        public IActionResult ShowQuestions()
        {
            var questions = _context.Questions
               .Include(x => x.Answers).ToList();

            var questionsModel = questions.Select(que => new QuestionModel()
            {
                Id = que.Id,
                Question = que.Question,
                Answers = que.Answers.Select(ans => new AnswerModel()
                {
                    Answer = ans.Answer,
                    IsCorrect = ans.IsCorrect,
                    SelectedAnswers = ans.SelectedAnswer
                }).ToList()
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
