using CrudApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
