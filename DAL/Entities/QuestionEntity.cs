using DAL.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Question")]
   public class QuestionEntity : Entity
    {
        public string Question { get; set; }
        public virtual ICollection<QuestionAnswers> QuestionAnswers { get; set; }
    }
}
