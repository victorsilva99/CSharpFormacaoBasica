namespace CSharpFormacaoBasica
{
    public class Strings
    {
        static void TipoString()
        {
            // Coleção sequência de caracteres

            string frase = "Bom dia!";

            // Métodos

            frase.Substring(0, 5); // Retorna conforme o valores (indice inicial, indice final)

            frase.Replace("Bom", "Mau"); // Troca os caracteres

            frase.Trim(); // Remove espaços vazios no inicio e no final da string
            frase.TrimEnd(); // Remove espaços vazios apenas do finald a string
            frase.TrimStart(); // Remove espaços vazios apenas do inicio da frase;

            frase = "Bom dia!!!!";
            frase.Trim('!'); // Caso encontrar, irá remove o caractere informado do inicio e do final da frase

            frase = "123456789";
            frase.PadLeft(11); // Faz com que a string tenha a quantidade de caracteres informado. Caso seja menor ele irá atribuir espaços em branco a esquerda
            frase.PadLeft(11, '0'); // Informa qual o caractere que será atribuido a esquerda até chegar no total informado
            frase.PadRight(11); // Mesma lógica do PadLeft, porém adicionando caracteres a direita
            frase.PadRight(11, '0');

            frase.ToUpper(); // Deixa todas as letras maiusculas
            frase.ToLower(); // Deixa todas as letras minusculas

            // Atribuições 

            string frase2 = frase + "uhull";

            string frase3 = $"Frase {frase}";

        }
    }
}
