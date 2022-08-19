namespace CSharpFormacaoBasica
{
    public class Dictionarys
    {
        static void TipoDictionary()
        {
            // Ele sempre trabalha com o conceito <chave, valor>, uma chave atrelada a um valor
            // As chaves são únicas, ou seja, se tentarmos adicionar uma chave que já existe ocorrerá um erro

            // Dictionary<tipo chave, tipo valor>
            Dictionary<int, string> estados = new Dictionary<int, string>();

            estados.Add(1, "RJ");
            estados.Add(2, "SP");
            estados.Add(3, "SC");

            //Verifica se a chave já existe - retorna um boolean
            estados.ContainsKey(4);

            if (!estados.ContainsKey(4))
                estados.Add(4, "MG");

            //percorrendo um dicionario
            foreach (var estado in estados.Values)
                Console.WriteLine(estado);

            //pegar um valor do dicionario - o indice não começa pelo 0, os indices são as própria chaves
            var est = estados[3];

            //Verifica se existe algum valor na chave informada, o retorno é atribuido na variavel informada no "out" -> retorna um bool
            estados.TryGetValue(3, out var outraVariavel);
        }
    }
}
