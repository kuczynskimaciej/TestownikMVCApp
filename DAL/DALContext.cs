using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{

    public class DALContext : DbContext
    {
        public DALContext(DbContextOptions<DALContext> options) : base(options)
        {
        }

        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }
    }
}
