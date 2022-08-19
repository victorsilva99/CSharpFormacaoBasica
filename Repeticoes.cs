namespace CSharpFormacaoBasica
{
    public class Repeticoes
    {
        static void EstruturaWhile()
        {
            // usado para fazer repetições dentro de uma condição

            int i = 0;

            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }

            // Perconrrendo um array
            int[] arrInt = new int[] { 1, 2, 3, 4, 5 };
            i = 0;
            while (i < arrInt.Length)
            {
                int numero = arrInt[i];
                Console.WriteLine(numero);
                i++;
            }
        }

        static void EstruturaFor()
        {
            // usado quando sabemos a quantidade de repetições
            int[] arrInt = new int[] { 1, 2, 3, 4, 5 };

            for (var i = 0; i <= arrInt.Length; i++)
            {
                int numero = arrInt[i];
                Console.WriteLine(numero);
            }
        }

        static void EstruturaForEach()
        {
            // Vai sempre trabalhar com lista, o numero de repetições é definido pelo tamanho da lista
            // Quando não precisamos trabalhar com indice, o foreach é recomendado

            int[] listaDeNumeros = new int[] { 1, 2, 3, 4, 5 };

            foreach (int numero in listaDeNumeros)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
