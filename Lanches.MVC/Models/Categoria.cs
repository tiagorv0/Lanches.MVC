using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches.MVC.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage ="O tamanho máximo é {1} caracateres")]
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é {1} caracateres")]
        [Required(ErrorMessage = "Informe a {0} da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        public List<Lanche> Lanches { get; set; }
    }
}
