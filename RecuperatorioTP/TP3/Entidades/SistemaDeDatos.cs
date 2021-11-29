using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class SistemaDeDatos
    {
        static List<Materia> listaDeMaterias;
        static List<Alumnos> listaDeAlumnos;

        public static List<Materia> ListaDeMaterias
        {
            get { return listaDeMaterias; }
        }
        public static List<Alumnos> ListaDeAlumnos
        {
            get { return listaDeAlumnos; }
        }

        static SistemaDeDatos()
        {
            listaDeMaterias = new List<Materia>();
            listaDeAlumnos = new List<Alumnos>();
        }
        /// <summary>
        /// metodo que analiza la lista que se le pase
        /// </summary>
        /// <typeparam name="T">tipo de objeto que contenga IAnalisis (va ser usada como un parecido a un metodo estatico sin serlo con esta interface)</typeparam>
        /// <param name="obj">objeto que va a denominar que tipo de lista va a evaluar</param>
        /// <param name="estudioDe">parametro que evalua un estudio que se pueda realizar del objeto</param>
        /// <param name="parametro">parametro que evalua el estudio</param>
        /// <returns>retorna el total estudiano</returns>
        public static int ResultadoDeAnalisis<T>(T obj, string estudioDe, string parametro) where T : IAnalisis, new()
        {
            try
            {
                if (obj.GetType() == typeof(Materia))
                {
                    return obj.AnalisisDeCantidad(ListaDeMaterias, estudioDe, parametro);
                }
                if (obj.GetType() == typeof(Alumnos))
                {
                    return obj.AnalisisDeCantidad(ListaDeAlumnos, estudioDe, parametro);
                }
                throw new Exception("La lista no es de un tipo que se pueda evaluar");
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static int ResultadoDeAnalisisSegunTurnos<T>(T lista, ETurno turno) where T : IAnalisis
        {
            try
            {
                return lista.AnalisisDeTurnos(turno);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// metodo que analiza la lista que se le pase
        /// </summary>
        /// <typeparam name="T">tipo de objeto que contenga IAnalisis (va ser usada como un parecido a un metodo estatico sin serlo con esta interface)</typeparam>
        /// <param name="obj">objeto que va a denominar que tipo de lista va a evaluar</param>
        /// <param name="catidadTotal">total que representa el 100%</param>
        /// <param name="catidadACalcular">cantidad a elvauar </param>
        /// <returns></returns>
        public static float ResultadoDeAnalisisEnPorcentajes<T>(T obj, int catidadTotal, int catidadACalcular) where T : IAnalisis
        {
            try
            {
                return obj.AnalisisEnPorcentaje(catidadTotal, catidadACalcular);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Analiza el total segun la lista y el parametro recibido
        /// </summary>
        /// <typeparam name="T">tipo de objeto que contenga IAnalisis (va ser usada como un parecido a un metodo estatico sin serlo con esta interface)</typeparam>
        /// <param name="obj">objeto que va a denominar que tipo de lista va a evaluar</param>
        /// <param name="parametro">parametro por el cual sera evaluada la lista</param>
        /// <returns></returns>
        public static int AnalizarTotal<T>(T obj, string parametro) where T : IAnalisis, new()
        {
            try
            {
                if (obj.GetType() == typeof(Materia))
                {
                    return obj.AnalizarTotal(parametro);
                }
                if (obj.GetType() == typeof(Alumnos))
                {
                    return obj.AnalizarTotal(parametro);
                }
                throw new Exception("La lista no es de un tipo que se pueda evaluar");
            }
            catch (Exception err)
            { 
                throw err;
            }
        }
        /// <summary>
        /// agrega una materia a la lista de Materias de la clase
        /// </summary>
        /// <param name="materia">nueva materia</param>
        /// <returns>true si se puedo, de lo contrario false</returns>
        public static bool AgregarMateria(Materia materia)
        {
            try
            {
                if ((!object.ReferenceEquals(listaDeMaterias, null)))
                {
                    if (!Materia.Existe(listaDeMaterias, materia))
                    {
                        listaDeMaterias += materia;
                        return true;
                    }
                    throw new Exception("Ya existe la materia que se quiere crear");
                }else
                {
                    listaDeMaterias += materia;
                    return true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// agrega un alumno a la lista de alumno de la clase
        /// </summary>
        /// <param name="alumno">nuevo alumno</param>
        /// <returns></returns>
        public static bool AgregarAlumno(Alumnos alumno)
        {
            try
            {
                if ((!object.ReferenceEquals(listaDeAlumnos, null)))
                {
                    listaDeAlumnos += alumno;
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// agrega un alumno a una materia
        /// </summary>
        /// <param name="alumno">alumno a agregar a una materia</param>
        /// <returns></returns>
        public static Alumnos AgregarAlumnoAMateria(Alumnos alumno)        
        {
            try
            {
                if ((!object.ReferenceEquals(listaDeMaterias, null)&&(!object.ReferenceEquals(alumno.Materias, null))))
                {
                    foreach (Materia item in alumno.Materias)
                    {
                        if (!Materia.Existe(listaDeMaterias, item))
                        {
                            listaDeMaterias += item;
                        }
                        else
                        {
                            item.CantAlumnos = item.CantAlumnos + 1 ;
                        }
                    }
                }
                return alumno;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// agrega una materia a un alumno
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="materia"></param>
        /// <returns>lista de materias</returns>
        public static List<Materia> AgregarMateriaAAlumno(Alumnos alumno, Materia materia)
        {
            try
            {
                if ((!object.ReferenceEquals(alumno.Materias, null)))
                {
                    alumno.AgrearMateria(materia);
                }
                return alumno.Materias;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static void HardCodeoDeDatos()
        {
            Materia matematica = new Materia(Materia.GenerarId(listaDeMaterias), "matematica", ETurno.mañana);
            Materia laboratorio = new Materia(Materia.GenerarId(listaDeMaterias), "laboratorio", ETurno.mañana);
            Materia programacion = new Materia(Materia.GenerarId(listaDeMaterias), "programacion", ETurno.mañana);
            Materia ingles = new Materia(Materia.GenerarId(listaDeMaterias), "ingles", ETurno.mañana);

            Alumnos alumno1 = new Alumnos(1, "mauricio", 19, "masculino", new List<Materia>() { matematica, laboratorio });
            Alumnos alumno2 = new Alumnos(2, "luciano", 21, "masculino", new List<Materia>() { programacion, ingles });
            Alumnos alumno3 = new Alumnos(3, "florensia", 21, "femenino", new List<Materia>() { programacion, laboratorio });

            listaDeMaterias += matematica;
            listaDeMaterias += laboratorio;
            listaDeMaterias += programacion;
            listaDeMaterias += ingles;

            listaDeAlumnos += AgregarAlumnoAMateria(alumno1);
            listaDeAlumnos += AgregarAlumnoAMateria(alumno2);
            listaDeAlumnos += AgregarAlumnoAMateria(alumno3);
        }
    }
}