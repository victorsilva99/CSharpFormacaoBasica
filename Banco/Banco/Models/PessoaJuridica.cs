namespace Banco.Models
{
    public class PessoaJuridica : Cliente
    {
        public string CNPJ { get; set; }

        public static List<Movimentacoes>? Movimentacoes { get; set; }
        public PessoaJuridica(string cnpj,
                            int conta,
                            int agencia,
                            string nome,
                            string endereco,
                            int senha,
                            decimal saldo) : base(conta, agencia, nome, endereco, saldo, senha)
        {
            CNPJ = cnpj;
        }
    }
}
