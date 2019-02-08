using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCX.Models
{
    [Table("subcategorias")]
    public class SubCategoria
    {
        [Key]
        public long IdSubCategoria{get;set;}

        [Required]
         public string Nome{get;set;}
        
    }
}