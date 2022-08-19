using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFormacaoBasica
{
    public class Tipos
    {
        public void ConhecendoTipos()
        {
            // Conhecidos também como Builtin Types
            // DOCS: https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/built-in-types

            //=========================================================
            /*--Atribuições Explícitas--*/
            //int
            int i = 10;

            //float
            float f = 10.9f;

            //double
            double d = 20.9d;

            //decimal
            decimal c = 30.9m;

            //bool
            bool b = true;
            bool b2 = false;

            //char
            char c2 = 'A';

            //string
            string s = "Victor";

            /*--Atribuições Implicita--*/
            //O compiçador espera a atribuição para definir o tipo
            var cidade = "São Paulo";
            var idade = 23;

            //=========================================================

            /*--Variaveis e constantes--*/
            idade = 24; // pode ser alterado ao longo da execução do programa

            const string pais = "Brasil"; // não pode ser alterado durante a execução do programa
                                          //pais = "Australia" -> Não é permitido

            //=========================================================

            /*--Conversões--*/

            //conversão implicita
            f = idade; // conversão de float para int

            //conversão explicita
            f = (float)c; // ele converte o decimal (c) para conseguir atribuir para o float

        }
    }
}
