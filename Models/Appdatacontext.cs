using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ResearchProflie.Models
{
    public class Appdatacontext : IdentityDbContext<Researcher>
    {
        public Appdatacontext(DbContextOptions<Appdatacontext> options) : base(options) { }

        public DbSet<Publications> Publications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Publications>()
                 .HasOne(p => p.ResearcherUser)
                 .WithMany(r => r.Publications)
                 .HasForeignKey(p => p.ResearcherId);

            base.OnModelCreating(modelBuilder);


        }


    }
}
