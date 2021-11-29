using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IAnalisis
    {
        int AnalisisDeCantidad(object lista, string nombreAnalisis, string parametro);
        int AnalisisDeTurnos(ETurno turno);
        float AnalisisEnPorcentaje(int catidadTotal, int catidadACalcular);
        int AnalizarTotal(string parametro);
        string ResultadosTotales(object lista);
    }
}
