using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class DBConexion
    {
        static private SqlConnection miConexion;
        static private SqlCommand consulta;

        static DBConexion()
        {
            DBConexion.miConexion = new SqlConnection();
            DBConexion.consulta = new SqlCommand();
            miConexion.ConnectionString = "Data Source = mgonzales\\SQLEXPRESS; Database = TP_SistemaDeDatos; Trusted_Connection=true;";
            DBConexion.consulta.CommandType = System.Data.CommandType.Text;
            DBConexion.consulta.Connection = DBConexion.miConexion;
        }
        public static int SelectAlumnos(List<Alumnos> listaAlumnos)
        {
            try
            {
                DBConexion.consulta.CommandText = "SELECT * FROM Alumnos";

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                int cargados = 0;
                while (datos.Read())
                {
                    Alumnos dato = new Alumnos(
                        int.Parse(datos["id"].ToString()),
                        datos["nombre"].ToString().Trim(),
                        int.Parse(datos["edad"].ToString()),
                        datos["genero"].ToString()
                        );

                    listaAlumnos += dato;
                    
                    cargados++;
                }
                return cargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static int SelectMateriasDeAlumnos(List<Alumnos> listaAlumnos, List<Materia> listaDeMterias)
        {
            try
            {
                DBConexion.consulta.CommandText = "SELECT id, materias FROM Alumnos";

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                int cargados = 0;
                while (datos.Read())
                {
                    Alumnos.AgrearMateriasAAlumno(listaDeMterias, listaAlumnos, int.Parse(datos["id"].ToString()), datos["nombre"].ToString().Trim());

                    cargados++;
                }
                return cargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los materias de los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static int InsertAlumnos(Alumnos alumno)
        {
            try
            {
                DBConexion.consulta.CommandText = "INSERT INTO Alumnos VALUES @id, @nombre, @edad, @genero, @materias";
                DBConexion.consulta.Parameters.Add(new SqlParameter("@id", alumno.Id));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@nombre", alumno.Nombre));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@edad", alumno.Edad));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@genero", alumno.Genero));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@materias", alumno.IdMaterias()));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                return  DBConexion.consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static int SelectMaterias(List<Materia> listaMaerias)
        {
            try
            {
                DBConexion.consulta.CommandText = "SELECT * FROM Materias";

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                int cargados = 0;
                while (datos.Read())
                {
                    Materia dato = new Materia(
                        int.Parse(datos["id"].ToString()),
                        datos["nombre"].ToString().Trim(),
                        int.Parse(datos["cantAlumnos"].ToString()),
                        Materia.AnalisisDeTurnos(datos["turno"].ToString().Trim())
                        );

                    listaMaerias += dato;

                    cargados++;
                }
                return cargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static int SelectAlumnosDeMaterias(List<Materia> listaDeMterias, List<Alumnos> listaAlumnos)
        {
            try
            {
                DBConexion.consulta.CommandText = "SELECT id, alumnos FROM Materias";

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                int cargados = 0;
                while (datos.Read())
                {
                    Materia.AgrearAlumnosAMateria(listaDeMterias, listaAlumnos, int.Parse(datos["id"].ToString()), datos["nombre"].ToString().Trim());

                    cargados++;
                }
                return cargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los materias de los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static int InsertMaterias(Materia materia)
        {
            try
            {
                try
                {
                    DBConexion.consulta.CommandText = "INSERT INTO Materias VALUES @id, @nombre, @cantAlumnos, @turno, @alumnos";
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@id", materia.Id));
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@nombre", materia.Nombre));
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@cantAlumnos", materia.CantAlumnos));
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@turno", materia.CantAlumnos));
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@alumnos", materia.IdAlumnos()));

                    if (miConexion.State != System.Data.ConnectionState.Open)
                    {
                        miConexion.Open();
                    }

                    return DBConexion.consulta.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
                }
                finally
                {
                    if (miConexion.State != System.Data.ConnectionState.Closed)
                    {
                        miConexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static int InsertAlumnoAMaterias(Materia materia, int id)
        {
            try
            {
                try
                {
                    DBConexion.consulta.CommandText = "UPDATE Materias SET alumnos=@alumnos WHERE id=@id";
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@id", materia.Id));
                    DBConexion.consulta.Parameters.Add(new SqlParameter("@alumnos", materia.IdAlumnos(id)));

                    if (miConexion.State != System.Data.ConnectionState.Open)
                    {
                        miConexion.Open();
                    }

                    return DBConexion.consulta.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
                }
                finally
                {
                    if (miConexion.State != System.Data.ConnectionState.Closed)
                    {
                        miConexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al cargar los Alumnos\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
    }
}
