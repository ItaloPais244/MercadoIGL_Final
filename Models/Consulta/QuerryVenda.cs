namespace MercadoIGL.Models.Consulta
{
    public class QuerryVenda
    {
        public int id { get; set; }
        public int produto { get; set; }
        public int cliente { get; set; }
        public int Funcionario { get; set; }
        public int quantidade { get; set; }
        public float valorTotal { get; set; }
    }
}
