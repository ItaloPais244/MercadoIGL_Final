using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int idFornecedor { get; set; }

        [Required(ErrorMessage = "CNPJ Obrigatorio")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "Nome da Empresa Obrigatorio")]
        [StringLength(100)]
        [Display(Name = "Empresa")]
        public string empresa { get; set; }

        [Required(ErrorMessage = "Telefone da Empresa Obrigatorio")]
        [StringLength(20)]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo Nome é OBRIGATORIO")]
        [StringLength(150)]
        [Display(Name = "Endereco")]
        public string endereco { get; set; }
    }
}
