using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SurveyBasket.API.Entites;



namespace SurveyBasket.API.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Poll> Polls { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {


        }


        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        }
    }
}
