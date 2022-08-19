namespace Banco.Models
{
    public class PessoaFisica : Cliente
    {
        public string CPF { get; set; }

        public PessoaFisica(string cpf, int conta,
                            int agencia,
                            string nome,
                            string endereco,
                            decimal saldo,
                            int senha,
                            List<Movimentacoes> movimentacoes
                            ) : base(movimentacoes, conta, agencia, nome, endereco, saldo, senha)
        {
            CPF = cpf;
        }

        public PessoaFisica()
        {
        }
    }
}
