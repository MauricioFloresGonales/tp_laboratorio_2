using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumnos: Encuesta,IAnalisis
    {
        int edad;
        string genero;
        List<Materia> materias;
        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }
        public string Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }
        public List<Materia> Materias
        {
            get { return this.materias; }
            set { this.materias = value; }
        }
        public Alumnos():base()
        {
            materias = new List<Materia>();
        }
        public Alumnos(int id, string nombre, int edad, string genero) : base(id, nombre)
        {
            this.edad = edad;
            this.genero = genero;
        }
        public Alumnos(int id, string nombre, int edad, string genero, List<Materia> materias) : this(id, nombre, edad, genero)
        {
            this.edad = edad;
            this.genero = genero;
            this.materias = materias;
        }
        public Alumnos(string nombre, int edad, string genero):base(nombre)
        {
            this.edad = edad;
            this.genero = genero;
        }
        public Alumnos(string nombre, int edad, string genero, List<Materia> materias) : this(nombre,edad,genero)
        {
            this.materias = materias;
        }

        #region Interface
        public int AnalisisDeCantidad(object listaDeAlumnos, string nombreAnalisis, string parametro)
        {
            try
            {
                if (listaDeAlumnos.GetType() == typeof(List<Alumnos>))
                {
                    List<Alumnos> listAux = (List<Alumnos>)listaDeAlumnos;
                    switch (nombreAnalisis)
                    {
                        case "nombre":
                            return AnalisisSegunNombre(listAux, parametro);
                        case "edad":
                            return AnalisisSegunEdad(listAux, parametro);
                        case "genero":
                            return AnalisisSegunGenero(listAux, parametro);
                        case "materias":
                            if (parametro == "total de materias")
                            {
                                return AnalisisSegunMaterias(listAux, parametro);
                            }
                            else
                            {
                                return AnalisisSegunCantMaterias(listAux, parametro);
                            }
                        default:
                            throw new Exception("No se ingreso un analisis valido.");
                    }
                }
                throw new Exception("No se ingresó una lista de alumnos.");
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public int AnalisisDeTurnos(ETurno turno)
        {
            int cantidad = 0;
            foreach (Materia item in this.materias)
            {
                if (item.Turno == turno)
                    cantidad += 1;
            }
            return cantidad;
        }
        public float AnalisisEnPorcentaje(int catidadTotal, int catidadACalcular)
        {
            return (float)((catidadACalcular * 100) / catidadTotal);
        }
        public static int AnalisisSegunNombre(object listaDeAlumnos, string nombre)
        {
            int i = 0;
            if (listaDeAlumnos.GetType() == typeof(List<Alumnos>))
            {
                List<Alumnos> listaAux = (List<Alumnos>)listaDeAlumnos;
                foreach (Alumnos item in listaAux)
                {
                    if (item.Nombre == nombre)
                    {
                        i++;
                    }
                }
            }
            return i;
        }
        public int AnalizarTotal(string parametro)
        {
            try
            {
                switch (parametro)
                {
                    case "nombre":
                    case "edad":
                    case "genero":
                    case "materias":
                        string resultado = DBConexion.SelectTotalDe("alumno", parametro);
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
        public string ResultadosTotales(object listaDeAlumnos)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (listaDeAlumnos.GetType() == typeof(List<Alumnos>))
                {
                    List<Alumnos> listaAux = (List<Alumnos>)listaDeAlumnos;
                    int totalNombre = this.AnalisisDeCantidad(listaAux, "nombre", this.Nombre);
                    int totalEdad = this.AnalisisDeCantidad(listaAux, "edad", this.Edad.ToString());
                    int totalGenero = this.AnalisisDeCantidad(listaAux, "genero", this.Genero.ToString());
                    int totalDeMaterias = this.AnalisisDeCantidad(listaAux, "materias", "total de materias");

                    sb.AppendLine($"- Alumno: {this.Nombre}");
                    sb.AppendLine($" - Mismo Nombre: {totalNombre} - Representa el {this.AnalisisEnPorcentaje(this.AnalizarTotal("nombre"), totalNombre)}% de los Nombres");
                    sb.AppendLine($" - Misma Edad: {totalEdad} -  Representa el {this.AnalisisEnPorcentaje(this.AnalizarTotal("edad"), totalEdad)}% de las Edades");
                    sb.AppendLine($" - Turnos: {totalGenero} -  Representa el {this.AnalisisEnPorcentaje(this.AnalizarTotal("genero"), totalGenero)}% de los Turno");
                    sb.AppendLine(" - Materias:");
                    sb.AppendLine($"  - con mayor concurrencia de alumnos tiene: {this.AnalisisDeCantidad(listaAux, "materias", "mayor concurrencia")} alumnos");
                    sb.AppendLine($"  - con menor concurrencia de alumnos tiene: {this.AnalisisDeCantidad(listaAux, "materias", "menor concurrencia")} alumnos");
                    sb.AppendLine("------------------------------------------------------");
                }
                return sb.ToString();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        #endregion

        public static int AnalisisSegunEdad(List<Alumnos> listaDeAlumnos, string edad)
        {
            int i = 0;
            int auxEdad;

            if (int.TryParse(edad, out auxEdad))
            {
                foreach (Alumnos item in listaDeAlumnos)
                {
                    if (item.Edad == auxEdad)
                    {
                        i++;
                    }
                }
            }
            return i;
        }
        public static int AnalisisSegunGenero(List<Alumnos> listaDeAlumnos, string genero)
        {
            int i = 0;
            foreach (Alumnos item in listaDeAlumnos)
            {
                if (item.Genero == genero)
                {
                    i++;
                }
            }
            return i;
        }
        public static int AnalisisSegunMaterias(List<Alumnos> listaDeAlumnos, string materia)
        {
            int i = 0;
            foreach (Alumnos item in listaDeAlumnos)
            {
                i += Materia.AnalisisSegunMaterias(item.Materias, materia);
            }
            return i;
        }
        public static int AnalisisSegunCantMaterias(List<Alumnos> listaDeAlumnos, string parametro)
        {
            int i = 0;
            switch (parametro)
            {
                case "mayor concurrencia":
                    foreach (Alumnos item in listaDeAlumnos)
                    {
                        if (i < item.Materias.Count)
                        {
                            i = item.Materias.Count;
                        }
                    }
                    break;
                case "menor concurrencia":
                    foreach (Alumnos item in listaDeAlumnos)
                    {
                        if (i > item.Materias.Count)
                        {
                            i = item.Materias.Count;
                        }
                    }
                    break;
                default:
                    throw new Exception("No se ingreso un parametro valido para analizar las materias");
            }
            return i;
        }
        public bool AgrearMateria(Materia materia)
        {
            try
            {
                if ((!object.ReferenceEquals(this.Materias, null)))
                {
                    this.materias+= materia;
                    return true;
                }
                return false;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public static void AgrearMateriasAAlumno(List<Materia> listaMaterias, List<Alumnos> listaAlumnos, int idAlumno, string materias)
        {
            try
            {
                if ((!object.ReferenceEquals(listaAlumnos, null)))
                {
                    int[] listaIds = Encuesta.TransformarStringIds(materias);
                    foreach (Alumnos item in listaAlumnos)
                    {
                        if (item.Id == idAlumno)
                        {
                            item.Materias = Encuesta.Encontrar(listaMaterias, listaIds);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public string IdMaterias()
        {
            if (!ReferenceEquals(this.Materias, null))
            {
                int lenght = this.Materias.Count;
                string[] ids = new string[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    ids[i] = DBConexion.SelectIdMateria(this.Materias[i]).ToString();
                }
                return String.Join(",", ids);
            }
            return "";
        }
        public static List<Alumnos> operator +(List<Alumnos> listaAlumnos, Alumnos alumno)
        {
            try
            {
                if (!object.ReferenceEquals(alumno, null))
                {
                    listaAlumnos.Add(alumno);
                    return listaAlumnos;
                }
                throw new Exception("El alumno que quiere ingresar en nulo");
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
