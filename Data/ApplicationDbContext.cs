using Hotel_Task.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Agent> Agents { get; set; }


        
    }
}
