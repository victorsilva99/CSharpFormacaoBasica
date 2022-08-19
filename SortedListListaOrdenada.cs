namespace CSharpFormacaoBasica
{
    public class SortedListListaOrdenada
    {
        static void TipoSortedList()
        {
            // SortedList = Lista ordenada
            // Ele trabalha com a atribuição <chave, valor>, igual ao Dictionary
            // SortedList<tipo chave, tipo valor>
            // A ordenação é feita pela chave

            var lista = new SortedList<int, string>();

            lista.Add(4, "RJ");
            lista.Add(2, "SP");
            lista.Add(1, "SC");
            lista.Add(3, "MG");

            foreach (var estado in lista.Values)
                Console.WriteLine(estado); // Irá trazer os valores já ordenados, indendente da sequência que foram inseridos

            //Verifica se a chave já existe - retorna um boolean
            lista.ContainsKey(5);

            if (!lista.ContainsKey(5))
                lista.Add(4, "MG");

            var est = lista[3];

            var quant = lista.Count; // quantidade de elementos

            //Verifica se existe algum valor na chave informada, o retorno é atribuido na variavel informada no "out" -> retorna um bool
            lista.TryGetValue(3, out var outraVariavel);

        }
    }
}
