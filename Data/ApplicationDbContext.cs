using GP_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace GP_Project.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Mark1> marks { get; set; }
    }
}
