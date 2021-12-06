using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MiExtencion
    {
        public static string Formato<T>(this Stack<T> materias)where T : Encuesta
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in materias)
            {
                sb.AppendLine(item.Nombre.ToString());
            }
            return sb.ToString();
        }
    }
}
