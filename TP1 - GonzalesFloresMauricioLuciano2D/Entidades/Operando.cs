using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        double numero;

        public string Numero 
        {
            set { this.numero = ValidarOperando(value); }
        }

        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero) : this()
        {
            this.numero = numero;
        }
        public Operando(string numero)
        {
            this.Numero = numero;
        }
        
        private double ValidarOperando(string strNumero)
        {
            double retorno;
            if(double.TryParse(strNumero, out retorno))
            {
                return retorno;
            }
            return retorno = 0;
        }
        private static bool EsBinario(string binario)
        {
            foreach (char numero in binario)
            {
                if (numero != '0' || numero != '1')
                {
                    return false;
                }
            }
            return true;
        }
        public static string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            { 
                char[] array = binario.ToCharArray();
                Array.Reverse(array);
                int sum = 0;
                
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }
                return sum.ToString();
            }
            return "Valor inválido";
        }
        public static string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        numeroBinario = "0" + numeroBinario;
                    }
                    else
                    {
                        numeroBinario = "1" + numeroBinario;
                    }
                    numero = (int)(numero / 2);
                }
                return numeroBinario;
            }
            else
            {
                if (numero == 0)
                {
                    numeroBinario = "0";
                }
                else
                {
                    numeroBinario = "Valor invalido";
                }
            }
            return numeroBinario;
        }
        public static string DecimalBinario(string numero)
        {
            string absoluto = numero.Replace('-', ' ').Trim();
            double aConvertir;

            if (double.TryParse(absoluto, out aConvertir))
            {
                return DecimalBinario(aConvertir);
            }
            return "valor inválido";
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            return (double)n1.numero / n2.numero;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }


    }
}
