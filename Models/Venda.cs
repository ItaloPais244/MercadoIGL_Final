using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int idVenda { get; set; }

        [Display(Name = "Produto")]
        public int idProduto { get; set; }
        [ForeignKey("idProduto")]
        public Produto produto { get; set; }

        [Display(Name = "Cliente")]
        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public Cliente cliente { get; set; }

        [Display(Name = "Funcionario")]
        public int idFuncionario { get; set; }
        [ForeignKey("idFuncionario")]
        public Funcionario funcionario { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int quantidade { get; set; }

        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float valorTotal { get; set; }

        [Display(Name = "Data")]
        public DateTime data { get; set; }
    }
}
