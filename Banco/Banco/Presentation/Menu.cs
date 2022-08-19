using Banco.Models;
using System.Text;

namespace Banco.Presentation
{
    public static class Menu
    {
        public static void Inicio()
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá! Bem vindo!");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Já é nosso cliente? (S/N)");
            Console.SetCursorPosition(3, 5);
            Console.Write("-> ");
            var resposta = Console.ReadKey().KeyChar;
            var respostaToUpper = Convert.ToString(resposta).ToUpper();

            switch (char.Parse(respostaToUpper))
            {
                case 'S': AcessarConta(); break;
                case 'N': NovoCliente(); break;
                default: Inicio(); break;
            }
        }

        public static void AcessarConta()
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá! Bem vindo!");
            Console.SetCursorPosition(3, 13);
            Console.Write("Pressione ESC para voltar ao menu");

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Informe sua agência e conta");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("Agência: ");
            var agencia = int.Parse(Input("agencia", 7));

            Console.SetCursorPosition(3, 8);
            Console.WriteLine("Conta: ");
            var conta = int.Parse(Input("conta", 9));

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("Senha: ");
            var senha = int.Parse(Input("senha", 11));

            var login = Cliente.LoginCPF(agencia, conta, senha);

            if (login != null)
                WriteOptions(login);
            else
            {
                Viewer.Mensagem("Usuário e/ou senha incorretos!");
                Thread.Sleep(2000);
                AcessarConta();
            }
        }

        public static string Input(string dado, int indiceX)
        {
            var input = new StringBuilder();
            var senha = dado.Contains("senha");
            var indice = 3;

            while (true)
            {
                Console.SetCursorPosition(indice, indiceX);
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Escape)
                    Inicio();

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input.Length--;
                        Console.SetCursorPosition(indiceX - 1, 11);
                        Console.Write(" ");

                        if (indiceX > 3)
                            indiceX--;
                    }
                }
                else
                {
                    input.Append(key.KeyChar);
                    if (senha)
                        Console.Write("*");
                    else
                        Console.Write(key.KeyChar.ToString());
                    indice++;
                }
            }

            return input.ToString();
        }

        public static void NovoCliente()
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá! Bem vindo!");

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Iremos realizar seu cadastro! :)");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("Informe por gentileza os seus dados: ");
            Console.SetCursorPosition(3, 8);
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.SetCursorPosition(3, 9);
            Console.Write("Endereço: ");
            var endereco = Console.ReadLine();
            Console.SetCursorPosition(3, 10);
            Console.Write("CPF/CNPJ: ");
            var cpfCnpj = Console.ReadLine();

            if (cpfCnpj != null)
            {
                cpfCnpj = cpfCnpj.Replace(".", "");
                cpfCnpj = cpfCnpj.Replace("/", "");

                if (cpfCnpj.Length == 11)
                    Cliente.CadastrarPessoaFisica(nome, endereco, cpfCnpj);
                if (cpfCnpj.Length == 14)
                    Cliente.CadastrarPessoaFisica(nome, endereco, cpfCnpj);
            }
            else
            {
                Viewer.Mensagem("O campo CPF/CNPJ não pode estar vazio!");
                NovoCliente();
            }
        }

        public static void WriteOptions(Cliente cliente)
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá {cliente.Nome}! Bem vindo!");

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Qual operação deseja fazer?");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Depositar");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Sacar");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("3 - Extrato");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 11);
            Console.Write("Opção: ");

            var option = Console.ReadLine() ?? "0";
            HandleMenuOption(short.Parse(option), cliente);
        }

        public static void HandleMenuOption(short option, Cliente cliente)
        {
            switch (option)
            {
                case 1: ShowDepositar(cliente); break;
                case 2: ShowSacar(cliente); break;
                case 3: ShowExtrato(cliente); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: WriteOptions(cliente); break;
            }
        }

        public static void ShowDepositar(Cliente cliente)
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá {cliente.Nome}! Bem vindo!");

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Informe o valor do depósito:");
            Console.SetCursorPosition(3, 6);
            Console.Write("Valor: ");
            var entradaValor = Console.ReadLine();
            decimal valor = 0;

            if (entradaValor != null)
                valor = decimal.Parse(entradaValor);

            cliente.DepositarCPF(cliente, valor);
        }

        public static void ShowSacar(Cliente cliente, string message = "")
        {
            Viewer.Show();
            Viewer.Mensagem(message);

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Informe o valor do saque:");
            Console.SetCursorPosition(3, 6);
            Console.Write("Valor: ");
            var entradaValor = Console.ReadLine();
            decimal valor = 0;

            if (entradaValor != null)
                valor = decimal.Parse(entradaValor);

            cliente.DepositarCPF(cliente, valor);
        }

        public static void ShowExtrato(Cliente cliente, string message = "")
        {
            Viewer.Show();
            Viewer.Mensagem(message);

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Saldo Atual:");

            var saldo = Cliente.ExtratoCPF(cliente.Conta);

            Console.SetCursorPosition(3, 6);
            Console.Write($"{string.Format("{0:C}", saldo)}");

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("Precione ENTER para voltar ao menu");
            Console.SetCursorPosition(3, 11);
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                WriteOptions(cliente);
            }
        }
    }
}
