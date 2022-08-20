using Banco.Models;
using System.Text;

namespace Banco.Presentation
{
    public static class Menu
    {
        public static void FinalizarPrograma()
        {
            Viewer.Show();
            Viewer.Mensagem("Obrigado por utilizar nosso sistema! Até a próxima!");
            Thread.Sleep(3000);
            Console.Clear();
            Environment.Exit(0);
        }

        public static void Inicio()
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá! Bem vindo!");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Já é nosso cliente? (S/N)");
            Console.SetCursorPosition(3, 13);
            Console.WriteLine("Pressione ESC para voltar...");
            Console.SetCursorPosition(3, 5);
            Console.Write("-> ");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                FinalizarPrograma();
            }

            var resposta = key.KeyChar;
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
            Console.Write("Agência: ");
            var agencia = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(3, 7);
            Console.Write("Conta: ");
            var conta = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(3, 8);
            Console.Write("Senha: ");
            var senha = int.Parse(InputSenha(10));

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

        public static string InputSenha(int indiceX)
        {
            var input = new StringBuilder();

            while (true)
            {
                if (indiceX < 10)
                    indiceX = 10;
                if (indiceX > (input.Length + 10))
                    indiceX = input.Length + 10;

                Console.SetCursorPosition(indiceX, 8);
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;
                else if (key.Key == ConsoleKey.Escape)
                    Inicio();
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input.Length--;
                        Console.SetCursorPosition(indiceX - 1, 8);
                        Console.Write(" ");

                        if (indiceX > 3)
                            indiceX--;
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (input.Length > 0)
                    {
                        Console.SetCursorPosition(indiceX - 1, 8);
                        indiceX--;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (input.Length > 0)
                    {
                        Console.SetCursorPosition(indiceX + 1, 8);
                        indiceX++;
                    }
                }
                else
                {
                    input.Append(key.KeyChar);
                    Console.Write("*");
                    indiceX++;
                }
            }

            return input.ToString();
        }

        public static void NovoCliente()
        {
            Viewer.Show();

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
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();

            var cpfOk = ValidarCPF(cpf);

            if (cpfOk)
            {
                var novoCliente = Cliente.CadastrarPessoaFisica(nome, endereco, cpf);
                ExibirDados(novoCliente);
            }
            else
            {
                Viewer.Mensagem("CPF inválido!");
                Thread.Sleep(2000);
                NovoCliente();
            }
        }

        public static void ExibirDados(Cliente cliente)
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Seu cadastro foi realizado com sucesso!");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Anote os dados da sua conta:");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine($"Agência: {cliente.Agencia}");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine($"Conta: {cliente.Conta}");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine($"Senha: {cliente.ObterSenha(cliente.Conta)}");

            Console.SetCursorPosition(3, 11);
            Console.WriteLine("Precione ENTER para voltar ao menu");
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                WriteOptions(cliente);
            }
        }

        public static bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static void WriteOptions(Cliente cliente)
        {
            Viewer.Show();
            Console.SetCursorPosition(3, 2);
            Console.WriteLine($"Olá {cliente.Nome}! Bem vindo! Saldo atual: {string.Format("{0:C}", ShowSaldo(cliente.Conta))}");

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
                        Viewer.Show();
                        Viewer.Mensagem("Obrigado por utilizar nossos serviços!!");
                        Thread.Sleep(3000);
                        Inicio();
                        break;
                    }
                default: WriteOptions(cliente); break;
            }
        }

        public static void ShowDepositar(Cliente cliente)
        {
            Viewer.Show();

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Informe o valor do depósito:");
            Console.SetCursorPosition(3, 6);
            Console.Write("Valor: ");
            var entradaValor = Console.ReadLine();
            decimal valor = 0;

            entradaValor = entradaValor.Replace(",", ".").Replace("R", "").Replace("$", "");

            if (entradaValor != null)
                valor = decimal.Parse(entradaValor.Trim());

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

            entradaValor = entradaValor.Replace(",", ".").Replace("R", "").Replace("$", "");

            if (entradaValor != null)
                valor = decimal.Parse(entradaValor.Trim());

            cliente.SacarCPF(cliente, valor);
        }

        public static void ShowExtrato(Cliente cliente, string message = "")
        {
            Viewer.Show();
            Viewer.Mensagem(message);

            var extrato = Cliente.ExtratoCPF(cliente.Conta);
            var saldo = ShowSaldo(cliente.Conta);

            Console.SetCursorPosition(3, 2);
            Console.WriteLine("--------------------- EXTRATO ---------------------");
            var indice = 3;
            foreach (var movimentacao in extrato)
            {
                Console.SetCursorPosition(3, indice);
                Console.WriteLine($"{string.Format("{0:g}", movimentacao.DataTransacao)} - {movimentacao.TipoMovimentacao,-8} - {string.Format("{0:C}", movimentacao.ValorMovimentado)}");
                indice++;
            }
            Console.SetCursorPosition(3, indice++);
            Console.WriteLine("---------------------------------------------------");
            Console.SetCursorPosition(3, indice++);
            Console.WriteLine($"Saldo Atual: {string.Format("{0:C}", saldo)}");

            Console.SetCursorPosition(3, indice++);
            Console.WriteLine("Precione ENTER para voltar ao menu");
            Console.SetCursorPosition(3, indice++);
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                WriteOptions(cliente);
            }
        }

        public static decimal ShowSaldo(int conta)
        {
            return Cliente.ObterSaldo(conta);
        }
    }
}
