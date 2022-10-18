using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyCoreProject.Models
{
    public class TestContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Question> Results { get; set; }
        public DbSet<Test> Tests { get; set; }
        

        public TestContext(DbContextOptions<TestContext> options)//создает бд при ее отсутствии
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
