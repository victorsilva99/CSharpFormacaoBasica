namespace Banco.Models
{
    public class PessoaJuridica : Cliente
    {
        public string CNPJ { get; set; }
        public PessoaJuridica(string cnpj,
                            int conta,
                            int agencia,
                            string nome,
                            string endereco,
                            int senha,
                            decimal saldo,
                            List<Movimentacoes> movimentacoes
                            ) : base(movimentacoes, conta, agencia, nome, endereco, saldo, senha)
        {
            CNPJ = cnpj;
        }
    }
}
