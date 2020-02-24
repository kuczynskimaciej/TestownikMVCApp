using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestownikMVCApp.Models
{
    public class AnswerModel
    {
        [Required(ErrorMessage = "Podaj odpowiedz")]
        [MinLength(3, ErrorMessage = "Minimum 3 znaki")]

        public string Answer { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public bool SelectedAnswers { get; set; }
    }
}
