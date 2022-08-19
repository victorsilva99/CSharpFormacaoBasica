namespace CSharpFormacaoBasica
{
    public class StackPilha
    {
        static void TipoStack()
        {
            // Stack = Pilha
            // Está dentro do conceito LIFO = Last In First Out (Ultimo a entrar é o primeiro a sair)
            // Ele não tem opção de ornadenação, ou seja, não tem como acessar indices

            var lista = new Stack<string>();
            lista.Push("Olá"); // Push = Empurrar -> adiciona o elemento na pilha
            lista.Push("Como");
            lista.Push("Vai");
            lista.Push("Você");
            lista.Push("?");

            lista.Pop(); // Pop = Disparar -> Remove o último elemento que entrou pilha (LIFO)

            var quant = lista.Count; // Quantidade de elementos na stack

            lista.Peek(); // Retorna o último elemento que foi adicionado

            foreach (var element in lista)
                Console.WriteLine(element); // O último que entrou é o primeiro a ser mostrado
        }
    }
}
