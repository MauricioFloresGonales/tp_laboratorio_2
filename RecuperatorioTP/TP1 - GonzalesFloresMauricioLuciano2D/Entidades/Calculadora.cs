using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            switch (ValidarOperador(operador))
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '/':
                    return num1 / num2;
                case '*':
                    return num1 * num2;
            }
            return 0;
        }
        private static char ValidarOperador(char operador)
        {
            string operadores = "-/*";

            for (int i = 0; i < operadores.Length; i++)
            {
                if(operadores[i].Equals(operador))
                {
                    return operador;
                }
            }
            return '+';
        }
    }
}
