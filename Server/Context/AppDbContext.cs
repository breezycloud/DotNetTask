using Shared.Models.Applicant;
using Microsoft.EntityFrameworkCore;
using Shared.Models.Questions;
using Shared.DTO.Questions;

namespace Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<ApplicantInfo> Applicants { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<YesNoQuestion> YesNoQuestions { get; set; }
        public DbSet<ParagraphQuestion> ParagraphQuestions { get; set; }
        public DbSet<NumberQuestion> NumberQuestions { get; set; }
        public DbSet<DateQuestion> DateQuestions { get; set; }
        public DbSet<MultichoiceQuestion> MultichoiceQuestions { get; set; }
        public DbSet<DropdownQuestion> DropdownQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ApplicantInfo>().Property(p => p.MultichoiceQuestionAnswers).HasColumnType("jsonb");
            //modelBuilder.Entity<ApplicantInfo>().Property(p => p.DropdownQuestionAnswers).HasColumnType("jsonb");
            //modelBuilder.Entity<ApplicantInfo>().Property(p => p.ParagraphQuestionAnswers).HasColumnType("jsonb");
            //modelBuilder.Entity<ApplicantInfo>().Property(p => p.YesNoQuestionAnswers).HasColumnType("jsonb");
            //modelBuilder.Entity<ApplicantInfo>().Property(p => p.DateQuestionAnswers).HasColumnType("jsonb");
            //modelBuilder.Entity<ApplicantInfo>().Property(p => p.NumberQuestionAnswers).HasColumnType("jsonb");
        }
    }
}
