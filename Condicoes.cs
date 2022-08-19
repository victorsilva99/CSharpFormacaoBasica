namespace CSharpFormacaoBasica
{
    public class Condicoes
    {
        static void CondicaoIf()
        {
            const string APROVADO = "Aprovado";
            const string REPROVADO = "Reprovado";
            const string EM_RECUPERACAO = "Em Recuperação";

            int nota = 10;

            if (nota > 5)
            {
                Console.WriteLine(APROVADO);
            }
            else if (nota == 5)
            {
                Console.WriteLine(EM_RECUPERACAO);
            }
            else
            {
                Console.WriteLine(REPROVADO);
            }
        }

        static void SwitchCase()
        {
            const string DIAS_31 = "Este mês tem 31 dias";
            const string DIAS_30 = "Este mês tem 30 dias";
            const string DIAS_28 = "Este mês tem 28 dias";

            string mes = "Janeiro";

            switch (mes)
            {
                case "Janeiro":
                case "Abril":
                    Console.WriteLine(DIAS_31);
                    break;
                case "Fevereiro":
                    Console.WriteLine(DIAS_28);
                    break;
                case "Março":
                    Console.WriteLine(DIAS_30);
                    break;
                default:
                    Console.WriteLine("Esse mês não existe");
                    break;
            }
        }
    }
}
