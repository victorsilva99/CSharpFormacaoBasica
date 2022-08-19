namespace Banco.Models
{
    public class Movimentacoes
    {
        public string Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public decimal ValorMovimentado { get; set; }
        public string TipoMovimentacao { get; set; }

        public Movimentacoes(string id, DateTime dataTransacao, decimal valorMovimentado, string tipoMovimentacao)
        {
            Id = id;
            DataTransacao = dataTransacao;
            ValorMovimentado = valorMovimentado;
            TipoMovimentacao = tipoMovimentacao;
        }

        public Movimentacoes() { }
    }
}