using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches.MVC.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [StringLength(80,MinimumLength = 6,ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracateres")]
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [BlockedNames]
        public string Nome { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "O Descrição deve ter no mínimo {1} e no máximo {2} caracateres")]
        [Required(ErrorMessage = "A Descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        public string DescricaoCurta { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "O Descrição detalhada deve ter no mínimo {1} e no máximo {2} caracateres")]
        [Required(ErrorMessage = "A Descrição detalhada deve ser informado")]
        [Display(Name = "Descrição detalhada do Lanche")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Display(Name ="Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage ="O preço deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name ="Categorias")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }

    public class BlockedNamesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var blockedNames = new List<string>() { "mclanche feliz", "big mac", "whopper", "big king" };

            return blockedNames.Contains(((string)value).ToLower())
                ? new ValidationResult("Nome Bloqueado! ")
                : ValidationResult.Success;
        }
    }
}
