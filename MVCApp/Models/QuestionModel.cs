﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestownikMVCApp.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
