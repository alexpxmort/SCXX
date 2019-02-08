using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCX.Models
{
    [Table("categorias")]
    public class Categoria
    {
    
        [Key]
        public long IdCategoria{get;set;}

        [Required]
         public string Nome{get;set;}
        
    }
}