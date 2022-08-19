namespace Banco.Models
{
    public class Movimentacoes
    {
        public static string Id { get; set; } = Guid.NewGuid().ToString()[..8];

        public static DateTime DataTransacao
        {
            get => DateTime.Now;
        }

        public decimal ValorMovimentado { get; set; }

        public PessoaJuridica? ClienteCNPJ { get; set; }

        public PessoaFisica? ClienteCPF { get; set; }

        public Movimentacoes(PessoaFisica pessoaFisica, decimal valorMovimentado)
        {
            ClienteCPF = pessoaFisica;
            ValorMovimentado = valorMovimentado;
        }

        public Movimentacoes(PessoaJuridica pessoaJuridica, decimal valorMovimentado)
        {
            ClienteCNPJ = pessoaJuridica;
            ValorMovimentado = valorMovimentado;
        }
    }
}