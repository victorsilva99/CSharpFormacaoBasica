using Banco.Presentation;

namespace Banco.Models
{
    public class Cliente
    {
        static List<PessoaFisica>? ClientesPessoaFisica = new List<PessoaFisica>();
        static List<PessoaJuridica> ClientesPessoaJuridica = new List<PessoaJuridica>();

        public int Conta { get; private set; }
        public int Agencia { get; private set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public decimal Saldo { get; private set; }
        private int Senha { get; set; }

        public Cliente() { }

        public Cliente(int conta, int agencia, string nome, string endereco, decimal saldo, int senha = 0)
        {
            Conta = conta;
            Agencia = agencia;
            Senha = senha;
            Nome = nome;
            Endereco = endereco;
            Saldo = saldo;
        }

        public Cliente(List<PessoaFisica> listaPessoaFisica, List<PessoaJuridica> listaPessoaJuridica)
        {
            ClientesPessoaFisica = listaPessoaFisica;
            ClientesPessoaJuridica = listaPessoaJuridica;
        }

        public static void CadastrarPessoaFisica(string nome, string endereco, string cpf)
        {
            var rand = new Random();
            var conta = rand.Next(1111, 9999);
            var agencia = rand.Next(11111, 99999);
            var senha = rand.Next(1111, 9999);

            var cliente = new PessoaFisica()
            {
                CPF = cpf,
                Conta = conta,
                Agencia = agencia,
                Nome = nome,
                Endereco = endereco,
                Saldo = 0m,
                Senha = senha
            };

            ClientesPessoaFisica.Add(cliente);

            Menu.WriteOptions(cliente);
        }

        public static Cliente LoginCPF(int agencia, int conta, int senha)
        {
            return ClientesPessoaFisica.FirstOrDefault(x => x.Conta == conta && x.Agencia == agencia && x.Senha == senha);
        }

        public void AtualizarSaldoCPF(int contaCliente, decimal valor)
        {
            ClientesPessoaFisica.FirstOrDefault(x => x.Conta == contaCliente).Saldo = valor;
        }

        public void SacarCPF(Cliente cliente, decimal saque)
        {
            if (cliente.Saldo < saque)
            {
                Viewer.Mensagem("Saldo insulficiente para saque");
                Menu.ShowSacar(cliente);
            }

            AtualizarSaldoCPF(cliente.Conta, saque);

            Viewer.Mensagem("Saque realizado com sucesso!");
            Thread.Sleep(2000);
            Menu.WriteOptions(cliente);
        }

        public void DepositarCPF(Cliente cliente, decimal deposito)
        {
            AtualizarSaldoCPF(cliente.Conta, deposito);

            Viewer.Mensagem("Deposito realizado com sucesso!");
            Thread.Sleep(2000);
            Menu.WriteOptions(cliente);
        }

        public static decimal ExtratoCPF(int conta)
        {
            return ClientesPessoaFisica.FirstOrDefault(x => x.Conta == conta).Saldo;
        }
    }
}
