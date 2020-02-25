using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Answer")]
    public class AnswerEntity : Entity
    {
        public string Answer { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
