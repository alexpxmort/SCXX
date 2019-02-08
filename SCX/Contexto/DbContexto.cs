using Microsoft.EntityFrameworkCore;
using SCX.Models;

namespace SCX.Contexto
{
    public class DbContexto:DbContext
    {
        public DbContexto(DbContextOptions<DbContexto>options):base(options){
            Database.EnsureCreated();
        }

        public DbSet<Categoria> Categorias{get;set;}
           public DbSet<SubCategoria> SubCategorias{get;set;}
        
    }
}