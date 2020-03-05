using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Relations
{
    public class QuestionAnswers
    {
        public QuestionEntity Question { get; set; }

        public AnswerEntity Answer { get; set; }

        public int AnswerId { get; set; }

        public int QuestionId { get; set; }
    }
}
