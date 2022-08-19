using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFormacaoBasica
{
    public class Operadores
    {
        public void Operacoes()
        {

            // ---- Operadores Aritiméticos -----
            // Sempre retornam um número
            // ( + - * / )
            int adicao = 5 + 3;
            int subtracao = 5 - 3;
            int multiplicacao = 5 * 3;
            int divisao = 15 / 3;

            // expressões
            int expr = (1 + 2) * 5 - 3 / 2;

            // ---- Operadores Relacionais ----
            // Comparacao de valores, sempre retornam um boolean
            // < > != == <= >= 
            string cidade1 = "São Bernardo do Campo";
            string cidade2 = "São Caetano";

            bool ret1 = cidade1 == cidade2;
            bool ret2 = cidade1 != cidade2;

            // com números
            int j = 1;
            int i = 2;

            bool ret3 = i == j;
            bool ret4 = i != j;
            bool ret5 = i > j;
            bool ret6 = i >= j;
            bool ret7 = i < j;
            bool ret8 = i <= j;

            // ---- Operadores Lógicos ----
            // Junção de 2 ou mais operadores relacionais
            //  ------ && ---------- 
            // false && false = False
            // true && false = False
            // false && true = False
            // true && true = True
            // -------- || ----------
            // false || false = false
            // false || true = true
            // true || false = true
            // true || true = true
            // -------- ! ----------
            // inverte o resultado da operação

            bool ret9 = i == j && cidade1 == cidade2;
            bool ret10 = i != j || cidade1 != cidade2;



        }
    }
}
