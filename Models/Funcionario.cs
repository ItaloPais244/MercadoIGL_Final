using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "CPF Obrigatório")]
        [Display(Name = "CPF")]
        [StringLength(14)]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo Nome é OBRIGATORIO")]
        [StringLength(30)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Cargo é OBRIGATORIO")]
        [StringLength(20)]
        [Display(Name = "Cargo")]
        public string cargo { get; set; }
    }
}
