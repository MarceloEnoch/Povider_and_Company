using Microsoft.EntityFrameworkCore;
using Povider_and_Company.Domain;

namespace Povider_and_Company.Persistence.Contextos
{
    public class Povider_and_Company_Context :DbContext
    {
        public Povider_and_Company_Context(DbContextOptions<Povider_and_Company_Context> options) : base(options){}
        public DbSet<Empresa> empresas{ get; set; }
        public DbSet<Fornecedor> fornecedores { get; set; }
        public DbSet<EmpresaFornecedor> empesasFornecedores { get; set; }
        public DbSet<Telefone> telefones { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=ProviCompaDB;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpresaFornecedor>()
                .HasKey(EF => new {EF.IdEmpresa, EF.IdFornecedor});
        }
    }
}
