namespace CSharpFormacaoBasica
{
    public class ArrayList
    {
        static void Array()
        {
            int[] numeros = new int[] { 1, 2, 3, 4, 5 };
            int[] numeros2 = new int[2];

            int num = numeros[0]; // Pegando valores pelo indice
            numeros[0] = 2; // mudando ou atribuindo um valor com base no indice
        }

        static void List()
        {
            // Usado quando a quantidade de elementos ainda é indefinida
            List<int> listNumeros = new List<int>();
            List<int> listNumeros2 = new List<int>() { 1, 2, 3, 4, 5 };

            var quantidadeDeNumeros = listNumeros.Count;
            listNumeros.Add(6); // Adiciona o valor a lista
            listNumeros.Remove(1); // Remove o valor da lista
            listNumeros.Clear(); // Limpa a lista


            var numeros = new List<int>() { 1, 0, 9, 6, 3, 5, 2, 8, 7, 4 };

            listNumeros.Sort(); // ordena os elementos
            foreach (var i in numeros)
                Console.WriteLine(i);
        }
    }
}
