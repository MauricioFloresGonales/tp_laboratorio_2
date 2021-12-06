using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaDeDatos.HardCodeoDeDatos();

            Materia objetoMateria = new Materia();
            int analisisMateria = SistemaDeDatos.ResultadoDeAnalisis(objetoMateria, "nombre", "laboratorio");
            float porcentajeMateria = SistemaDeDatos.ResultadoDeAnalisisEnPorcentajes(objetoMateria, SistemaDeDatos.AnalizarTotal(objetoMateria, "nombre"), int analisisMateria = SistemaDeDatos.ResultadoDeAnalisis(objetoMateria, "nombre", "laboratorio");
);

            Console.WriteLine($"El resultado del analisis es {analisisMateria} y el porcentaje es el {porcentajeMateria}% del totoal de materias");
            Console.ReadKey();

            Alumnos objetoAlumno = new Alumnos();
            int analisisAlumno = SistemaDeDatos.ResultadoDeAnalisis(objetoAlumno, "nombre", "mauricio");
            float porcentajeAlumno = SistemaDeDatos.ResultadoDeAnalisisEnPorcentajes(objetoAlumno, SistemaDeDatos.AnalizarTotal(objetoAlumno, "nombre"), analisisAlumno);

            Console.WriteLine($"El resultado del analisis es {analisisAlumno} y el porcentaje es el {porcentajeAlumno}% del totoal de materias");
            Console.ReadKey();
        }
    }
}
