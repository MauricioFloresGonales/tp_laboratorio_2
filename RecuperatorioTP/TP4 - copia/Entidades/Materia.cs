using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETurno
    {
        mañana,
        tarde
    }
    public class Materia : Encuesta, IAnalisis
    {
        int cantAlumnos;
        ETurno turno;
        List<Alumnos> alumnos;
        public int CantAlumnos
        {
            get { return this.cantAlumnos; }
            set 
            { 
                if (value > 0)
                {
                    this.cantAlumnos += value;
                }
                else
                {
                    throw new Exception("No se puede sumar un numero menor a cero a cantidad de alumnos");
                }
            }
        }
        public ETurno Turno
        {
            get { return this.turno; }
            set { this.turno = value; }
        }
        public List<Alumnos> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Materia():base()
        {
            alumnos = new List<Alumnos>();
        }
        public Materia(string nombre, ETurno turno) : base(nombre)
        {
            this.turno = turno;
        }
        public Materia(int id, string nombre, ETurno turno) : base(id, nombre)
        {
            this.turno = turno;
        }
        public Materia(int id, string nombre, int cantAlumnos, ETurno turno) : this(id, nombre, turno)
        {
            this.cantAlumnos = cantAlumnos;
        }
        public Materia(int id, string nombre, int cantAlumnos, ETurno turno, List<Alumnos> alumnos) : this(id, nombre, cantAlumnos, turno)
        {
            this.alumnos = alumnos;
        }

        /// <summary>
        /// Metodo que almasena todos los metodos que retornan algun analisis de cantidad segun su paramentro
        /// </summary>
        /// <param name="listaDeMaterias"> lista de tipo Materia</param>
        /// <param name="nombreAnalisis">nombre del analisis a realizar opciones: nombre, cantidad de Alumnos, turno</param>
        /// <param name="parametro">texto por el cual se va a evaluar la cantidad existente</param>
        /// <returns>enteri que representa la cantidad evaluada</returns>
        public int AnalisisDeCantidad(object listaDeMaterias, string nombreAnalisis, string parametro)
        {
            try
            {
                if (listaDeMaterias.GetType() == typeof(List<Materia>))
                {
                    List<Materia> listaAux = (List<Materia>)listaDeMaterias;
                    switch (nombreAnalisis)
                    {
                        case "nombre":
                            return AnalisisSegunMaterias(listaAux, parametro);
                        case "cantidad de Alumnos":
                            return AnalisisSegunCantAlumnos(listaAux, parametro);
                        case "turno":
                            return AnalisisSegunTurno(listaAux, parametro);
                        default:
                            throw new Exception("No se ingreso un analisis valido.");
                    }
                }
                throw new Exception("El tipo de lista no es de Materias");
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Metodo que analiza si el turno es el mismo que el del parametro
        /// </summary>
        /// <param name="turno">enum ETurno</param>
        /// <returns>1 verdadero, 0 falso</returns>
        public int AnalisisDeTurnos(ETurno turno)
        {
            try
            {
                return (this.Turno == turno) ? 1 : 0;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Metodo que saca el porsentaje de segun los parametros que se pasen
        /// (se utilizo de esta manera ya que se necesitaba que sea parte de la interface)
        /// </summary>
        /// <param name="catidadTotal"></param>
        /// <param name="catidadACalcular"></param>
        /// <returns>porcentaje evaluado</returns>
        public float AnalisisEnPorcentaje(int catidadTotal, int catidadACalcular)
        {
            return (float)((catidadACalcular * 100) / catidadTotal);
        }
        /// <summary>
        /// Metodo que retorna el total del parametro que se le pase
        /// </summary>
        /// <param name="parametro">opciones: nombre, cantidad de Alumnos, turno</param>
        /// <returns>int que representa el total del parametro evaluado</returns>
        public int AnalizarTotal(string parametro)
        {
            try
            {
                switch (parametro)
                {
                    case "nombre":
                    case "cantidad de Alumnos":
                    case "turno":
                        string resultado = DBConexion.SelectTotalDe("materia", parametro);
                        return int.Parse(resultado);
                    default:
                        throw new Exception("No se ingreso un analisis valido.");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Metodo que retorna un texto que muestra todo los resultados posibles que se pueden lograr de una Materia
        /// </summary>
        /// <param name="listaDeMaterias">lista de Materia</param>
        /// <returns>string personalizado con la evaluacion de la lista de materias</returns>
        public string ResultadosTotales(object listaDeMaterias)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (listaDeMaterias.GetType() == typeof(List<Materia>))
                {
                    List<Materia> listaAux = (List<Materia>)listaDeMaterias;
                    int totalNombre = this.AnalisisDeCantidad(listaAux, "nombre", this.Nombre);
                    int totalCantAlumnos = this.AnalisisDeCantidad(listaAux, "cantidad de Alumnos", this.Nombre);
                    int totalTurno = this.AnalisisDeCantidad(listaAux, "turno", this.Turno.ToString());

                    sb.AppendLine($"- Materia: {this.Nombre}");
                    sb.AppendLine($" - Materias con el mismo nombre: {totalNombre} - Representa el {this.AnalisisEnPorcentaje(this.AnalizarTotal("nombre"), totalNombre)}% de los alumnos");
                    sb.AppendLine($" - Cantidad De Alumnos: {totalCantAlumnos} - Representa el {this.AnalisisEnPorcentaje(this.AnalizarTotal("cantidad de Alumnos"), totalCantAlumnos)}% de total de alumnos");
                    sb.AppendLine($" - Con el mismo Turno: {totalTurno} - Representa el {this.AnalisisEnPorcentaje(this.AnalizarTotal("turno"), totalTurno)}% de los turnos");
                    sb.AppendLine("------------------------------------------------------");
                }
                return sb.ToString();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Metdo que analiza los turnos segun el turno que se le ingrese
        /// </summary>
        /// <param name="listaDeMaterias">listaDeMaterias</param>
        /// <param name="turno">turno a evaluar</param>
        /// <returns>entero que representa el total de materias con el mismo turno</returns>
        public static int AnalisisSegunTurno(List<Materia> listaDeMaterias, string turno)
        {
            try
            {
                int i = 0;

                foreach (Materia item in listaDeMaterias)
                {
                    if (item.AnalisisDeTurnos(AnalisisDeTurnos(turno)) ==1)
                    {
                        i++;
                    }
                }
                return i;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// metodo que devuelve un ETurno si esxiste en el enumerador
        /// </summary>
        /// <param name="turno">turno a evaluar</param>
        /// <returns>valor del enumerador evaluado</returns>
        public static ETurno AnalisisDeTurnos(string turno)
        {
            try
            {
                switch (turno)
                {
                    case "mañana":
                        return ETurno.mañana;
                    case "tarde":
                        return ETurno.tarde;
                    default:
                        throw new Exception("No se ingreso un turno valido");
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// metodo que evalua las materias iguales al parametro
        /// </summary>
        /// <param name="listaDeMaterias"> list de Materia</param>
        /// <param name="materia">parametro a evaluar</param>
        /// <returns>cantidad de materias iguales al parametro</returns>
        public static int AnalisisSegunMaterias(List<Materia> listaDeMaterias, string materia)
        {
            try
            {
                int i = 0;

                foreach (Materia item in listaDeMaterias)
                {
                    if (item.Nombre == materia)
                    {
                        i++;
                    }
                }
                return i;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// metodo que analiza la cantidad de usuarios con la misma materia pasada por parametro
        /// </summary>
        /// <param name="listaDeMaterias"> list de Materia</param>
        /// <param name="materia">parametro a evaluar</param>
        /// <returns>cantidad de alumnos en esa materia</returns>
        public static int AnalisisSegunCantAlumnos(List<Materia> listaDeMaterias, string materia)
        {
            try
            {
                foreach (Materia item in listaDeMaterias)
                {
                    if (item.Nombre == materia)
                    {
                        return item.CantAlumnos;
                    }
                }
                throw new Exception($"No se encontró la materia {materia}");
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// metodo que genera el id de la materia
        /// </summary>
        /// <param name="listaMaterias"> list de Materia</param>
        /// <returns>nuevo id</returns>
        public static int GenerarId(List<Materia> listaMaterias)
        {
            if (!object.ReferenceEquals(listaMaterias, null))
            {
                if (listaMaterias.Count == 0)
                {
                    return 1;
                }
                int i = 0;
                foreach (Materia item in listaMaterias)
                {
                    if (item.Id != i)
                    {
                        i++;
                    }
                    else
                    {
                        return i;
                    }
                }
            }
            throw new Exception("La lista ingresada es nula");
        }
        /// <summary>
        /// metodo que valida si esxite la materia que se le pase por parametro
        /// </summary>
        /// <param name="listaMaterias"> list de Materia</param>
        /// <param name="nuevaMateria">materia a evaluar si existe</param>
        /// <returns>true si existe, de lo contrario false</returns>
        public static bool Existe(List<Materia> listaMaterias, Materia nuevaMateria)
        {
            if (!object.ReferenceEquals(listaMaterias, null))
            {
                foreach (Materia item in listaMaterias)
                {
                    if (item == nuevaMateria)
                    {
                        return true;
                    }
                }
                return false;
            }
            throw new Exception("La lista ingresada es nula");
        }
        /// <summary>
        /// metodo que agrega un alumno a una materia
        /// </summary>
        /// <param name="listaMaterias">list de materias</param>
        /// <param name="listaAlumnos">list de alumnos</param>
        /// <param name="idMateria">id de la materia</param>
        /// <param name="materias">nombre de la materia</param>
        public static void AgrearAlumnosAMateria(List<Materia> listaMaterias, List<Alumnos> listaAlumnos, int idMateria, string materias)
        {
            try
            {
                if ((!object.ReferenceEquals(listaAlumnos, null)))
                {
                    int[] listaIds = Encuesta.TransformarStringIds(materias);
                    foreach (Materia item in listaMaterias)
                    {
                        if (item.Id == idMateria)
                        {
                            item.Alumnos = Encuesta.Encontrar(listaAlumnos, listaIds);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// metodo que crea un string con los ids de los alumno que tiene dentro
        /// </summary>
        /// <returns>string de ids de alumnos</returns>
        public string IdAlumnos()
        {
            if(!object.ReferenceEquals(this.Alumnos, null))
            {
                int lenght = this.Alumnos.Count;
                string[] ids = new string[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    ids[i] = DBConexion.SelectIdAlumno(this.Alumnos[i]).ToString();
                }
                return String.Join(",", ids);
            }
            return "";
        }
        /// <summary>
        /// evalua si el id pasado por parametro existe para poder agregarlo a string que se devolvera
        /// </summary>
        /// <param name="id">id a evaluar</param>
        /// <returns>string de ids de alumnos sin el id repetido si es el caso</returns>
        public string IdAlumnos(int id)
        {
            if (!object.ReferenceEquals(this.Alumnos, null))
            {
                
                int lenght = this.Alumnos.Count;
                string[] ids = new string[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    bool existe = false;
                    foreach (Alumnos item in this.Alumnos)
                    {
                        if (id == item.Id)
                        {
                            existe = true;
                        }
                    }
                    if (existe == false)
                    {
                        ids[i] = this.Alumnos.ElementAt(i).Id.ToString();
                    }
                }
                return String.Join(",", ids);
            }
            return "";
        }
        /// <summary>
        /// agrega la materia a lista  de materias
        /// </summary>
        /// <param name="listaMaterias">list de materias</param>
        /// <param name="materia">materia a agregar a la lista</param>
        /// <returns>lista con la materia agregada si se pudo, de lo contrario la misma lista que se ingreso como parametro</returns>
        public static List<Materia> operator +(List<Materia> listaMaterias, Materia materia)
        {
            if (!object.ReferenceEquals(materia, null))
            {
                if (listaMaterias.Count == 0)
                {
                    listaMaterias.Add(materia);
                }
                else
                {
                    foreach (Materia item in listaMaterias)
                    {
                        if (item == materia)
                        {
                            throw new Exception("La Materia ya existe");
                        }
                    }
                    listaMaterias.Add(materia);
                }
            }
            return listaMaterias;
        }
        /// <summary>
        /// compara si dos materias son iguales
        /// </summary>
        /// <param name="materia1"></param>
        /// <param name="materia2"></param>
        /// <returns></returns>
        public static bool operator ==(Materia materia1, Materia materia2)
        {
            if (!object.ReferenceEquals(materia1, null) && !object.ReferenceEquals(materia2, null))
            {
                if (materia1.Nombre == materia2.Nombre)
                {
                    if (materia1.Turno == materia2.Turno)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// evalua que las materias no sean iguales
        /// </summary>
        /// <param name="materia1"></param>
        /// <param name="materia2"></param>
        /// <returns></returns>
        public static bool operator !=(Materia materia1, Materia materia2)
        {
            return !(materia1 == materia2);
        }
    }
}
