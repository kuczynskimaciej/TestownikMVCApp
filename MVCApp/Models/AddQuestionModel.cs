using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestownikMVCApp.Models
{
    public class AddQuestionModel
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
    }
}
