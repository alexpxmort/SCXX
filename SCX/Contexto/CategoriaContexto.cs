using Microsoft.EntityFrameworkCore;
using SCX.Models;

namespace SCX.Contexto
{
    public class CategoriaContexto:DbContext
    {
        public CategoriaContexto(DbContextOptions<CategoriaContexto>options):base(options){
            Database.EnsureCreated();
        }

        public DbSet<Categoria> Categorias{get;set;}
        
    }
}