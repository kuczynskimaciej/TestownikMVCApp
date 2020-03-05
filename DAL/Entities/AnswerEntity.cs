using DAL.Relations;
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

        public bool IsCorrect { get; set; }

        public virtual ICollection<QuestionAnswers> QuestionAnswers { get; set; }
    }
}
