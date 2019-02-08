using Microsoft.EntityFrameworkCore;
using SCX.Models;

namespace SCX.Contexto
{
    public class SubCategoriaContexto:DbContext
    {
        
        public SubCategoriaContexto(DbContextOptions<CategoriaContexto>options):base(options){
            Database.EnsureCreated();
        }

        public DbSet<SubCategoria> SubCategorias{get;set;}
    }
}