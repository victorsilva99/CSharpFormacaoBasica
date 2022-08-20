using Banco.Presentation;

namespace Banco.Models
{
    public class Cliente
    {
        static List<PessoaFisica> ClientesPessoaFisica = new();
        static List<PessoaJuridica> ClientesPessoaJuridica = new();

        public List<Movimentacoes> Movimentacoes { get; set; }
        public int Conta { get; private set; }
        public int Agencia { get; private set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public decimal Saldo { get; private set; }
        private int Senha { get; set; }

        public Cliente() { }

        public Cliente(List<Movimentacoes> movimentacoes, int conta, int agencia, string nome, string endereco, decimal saldo, int senha = 0)
        {
            Movimentacoes = movimentacoes;
            Conta = conta;
            Agencia = agencia;
            Senha = senha;
            Nome = nome;
            Endereco = endereco;
            Saldo = saldo;
        }

        public Cliente(List<Movimentacoes> movimentacoes, List<PessoaFisica> listaPessoaFisica, List<PessoaJuridica> listaPessoaJuridica)
        {
            Movimentacoes = movimentacoes;
            ClientesPessoaFisica = listaPessoaFisica;
            ClientesPessoaJuridica = listaPessoaJuridica;
        }

        public int ObterSenha(int conta)
        {
            return ClientesPessoaFisica.FirstOrDefault(x => x.Conta == conta).Senha;
        }

        public static Cliente CadastrarPessoaFisica(string nome, string endereco, string cpf)
        {
            var rand = new Random();
            var conta = rand.Next(11111, 99999);
            var agencia = rand.Next(1111, 9999);
            var senha = rand.Next(1111, 9999);

            var cliente = new PessoaFisica()
            {
                Movimentacoes = new List<Movimentacoes>(),
                CPF = cpf,
                Conta = conta,
                Agencia = agencia,
                Nome = nome,
                Endereco = endereco,
                Saldo = 0m,
                Senha = senha
            };

            ClientesPessoaFisica.Add(cliente);

            return cliente;
        }

        public static Cliente LoginCPF(int agencia, int conta, int senha)
        {
            return ClientesPessoaFisica.FirstOrDefault(x => x.Conta == conta && x.Agencia == agencia && x.Senha == senha);
        }

        public void AtualizarSaldoCPF(int contaCliente, decimal valor, string operacao)
        {
            if (operacao.Contains("Deposito"))
                ClientesPessoaFisica.FirstOrDefault(x => x.Conta == contaCliente).Saldo += valor;
            else
                ClientesPessoaFisica.FirstOrDefault(x => x.Conta == contaCliente).Saldo -= valor;
        }

        public void SacarCPF(Cliente cliente, decimal saque)
        {
            if (cliente.Saldo < saque)
            {
                Viewer.Mensagem("Saldo insulficiente para saque!");
                Thread.Sleep(2000);
                Menu.ShowSacar(cliente);
            }

            AtualizarSaldoCPF(cliente.Conta, saque, "Saque");
            cliente.Movimentacoes.Add(new Movimentacoes()
            {
                Id = Guid.NewGuid().ToString()[..8],
                DataTransacao = DateTime.Now,
                ValorMovimentado = saque,
                TipoMovimentacao = "Saque"
            });

            Viewer.Mensagem("Saque realizado com sucesso!");
            Thread.Sleep(2000);
            Menu.WriteOptions(cliente);
        }

        public void DepositarCPF(Cliente cliente, decimal deposito)
        {
            AtualizarSaldoCPF(cliente.Conta, deposito, "Deposito");

            var movimentacao = new Movimentacoes()
            {
                Id = Guid.NewGuid().ToString()[..8],
                DataTransacao = DateTime.Now,
                ValorMovimentado = deposito,
                TipoMovimentacao = "Deposito"
            };

            cliente.Movimentacoes.Add(movimentacao);
            Viewer.Mensagem("Depósito realizado com sucesso!");
            Thread.Sleep(2000);
            Menu.WriteOptions(cliente);
        }

        public static List<Movimentacoes> ExtratoCPF(int conta)
        {
            return ClientesPessoaFisica.FirstOrDefault(x => x.Conta == conta).Movimentacoes;
        }

        public static decimal ObterSaldo(int conta)
        {
            return ClientesPessoaFisica.FirstOrDefault(x => x.Conta == conta).Saldo;
        }
    }
}
