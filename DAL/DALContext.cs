using DAL.Entities;
using DAL.Relations;
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

        public DbSet<QuestionAnswers> QuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionAnswers>()
       .HasKey(bc => new { bc.AnswerId, bc.QuestionId });

            modelBuilder.Entity<QuestionAnswers>()
                  .HasOne(e => e.Question)
                  .WithMany(e => e.QuestionAnswers)
                  .HasForeignKey(e => e.QuestionId);

            modelBuilder.Entity<QuestionAnswers>()
                .HasOne(e => e.Answer)
                .WithMany(e => e.QuestionAnswers)
                .HasForeignKey(e => e.AnswerId);
        }
    }
}
