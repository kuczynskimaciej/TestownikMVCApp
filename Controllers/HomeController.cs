using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestownikMVCApp.Models;

namespace TestownikMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Testownik()
        {
            Random rnd = new Random();

            List<QuestionModel> _listOfQuestions = new List<QuestionModel>();
            QuestionModel question1 = new QuestionModel();
            question1.Question = "Ile to jest 2+2?";
            question1.Answers = new List<AnswerModel>();
            question1.Answers.Add(new AnswerModel() { Answer = "1", IsCorrect = false });
            question1.Answers.Add(new AnswerModel() { Answer = "2", IsCorrect = false });
            question1.Answers.Add(new AnswerModel() { Answer = "3", IsCorrect = false });
            question1.Answers.Add(new AnswerModel() { Answer = "4", IsCorrect = true });

            QuestionModel question2 = new QuestionModel();
            question2.Question = "Co idzie ze sobą w parze?";
            question2.Answers = new List<AnswerModel>();
            question2.Answers.Add(new AnswerModel() { Answer = "Wódka", IsCorrect = true });
            question2.Answers.Add(new AnswerModel() { Answer = "Zakąska", IsCorrect = true });
            question2.Answers.Add(new AnswerModel() { Answer = "3", IsCorrect = false });
            question2.Answers.Add(new AnswerModel() { Answer = "4", IsCorrect = false });

            QuestionModel question3 = new QuestionModel();
            question3.Question = "Ulubiony kolor?";
            question3.Answers = new List<AnswerModel>();
            question3.Answers.Add(new AnswerModel() { Answer = "Niebieski", IsCorrect = true });
            question3.Answers.Add(new AnswerModel() { Answer = "Czerwony", IsCorrect = false });
            question3.Answers.Add(new AnswerModel() { Answer = "Zielony", IsCorrect = false });
            question3.Answers.Add(new AnswerModel() { Answer = "Czarny", IsCorrect = false });

            _listOfQuestions.Add(question1);
            _listOfQuestions.Add(question2);
            _listOfQuestions.Add(question3);

            var countOfQuestions = _listOfQuestions.Count();
            var indexOfRandomQuestion = rnd.Next(countOfQuestions);
            var question = _listOfQuestions.ElementAt(indexOfRandomQuestion);

            return View(question);
        }
        public IActionResult CheckAnswers(QuestionModel model)
        {
            return View(model);
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
