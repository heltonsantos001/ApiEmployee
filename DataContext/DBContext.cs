using Microsoft.EntityFrameworkCore;
using WebApiVideo.Model;

namespace WebApiVideo.DataContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> Options) : base(Options)
        {
        }

        public DbSet<FuncionarioModel> Funcionario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
     

    }
}


