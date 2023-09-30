using BudgetTool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetTool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Content> Content { get; set; }
        //public DbSet<Quiz> quizzes { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<EducationalContent>()
        //        .HasOne(e => e.quiz)
        //        .WithOne(q => q.educationalContent)
        //        .HasForeignKey<Quiz>(q => q.EducationalContentId);
        //}
    }
}