using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int idCliente { get; set; }

        [Required(ErrorMessage = "CPF Obrigatório")]
        [Display(Name = "CPF")]
        [StringLength(14)]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string nome { get; set; }

        [Display(Name = "Endereço Completo")]
        [StringLength(150)]
        public string endereco { get; set; }
    }
}
