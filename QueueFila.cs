namespace CSharpFormacaoBasica
{
    public class QueueFila
    {
        static void TipoQueue()
        {
            // Queue = Fila
            // Está dentro do conceito FIFO = First In First Out (primeiro a entrar é o primeiro a sair)
            // Ele não tem opção de ornadenação, ou seja, não tem como acessar indices 

            var lista = new Queue<string>();
            lista.Enqueue("Olá"); // Enqueue = Enfileirar -> Adiciona um elemento na fila
            lista.Enqueue("Como");
            lista.Enqueue("Você");
            lista.Enqueue("?");
            lista.Dequeue(); // Remove o primeiro elemento da lista (FIFO) -> retorna o elemento excluido
            var quant = lista.Count; // Quantidade de elementos na queue
            lista.Peek(); // Retorna o primeiro elemento

            foreach (var element in lista)
                Console.WriteLine(element); // O primeiro que entrou é o primeiro a ser mostrado

        }
    }
}
