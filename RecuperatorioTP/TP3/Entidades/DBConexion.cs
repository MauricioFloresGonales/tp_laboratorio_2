using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            miConexion.ConnectionString = "Data Source = BUEGSMGONB; Database = TP_SistemaDeDatos; Trusted_Connection=true;";
            DBConexion.consulta.CommandType = System.Data.CommandType.Text;
            DBConexion.consulta.Connection = DBConexion.miConexion;
        }
        public static int SelectIdAlumno(Alumnos alumno)
        {
            try
            {
                DBConexion.consulta.CommandText = "SELECT id FROM Alumnos WHERE id=@id";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@id", alumno.Id));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }
                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                int cargados = 0;
                while (datos.Read())
                {
                    cargados = int.Parse(datos["id"].ToString());
                }
                return cargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al querer encontrar el Id del alumno\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
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
                string materias = alumno.IdMaterias();
                DBConexion.consulta.CommandText = "INSERT INTO Alumnos VALUES(@nombre, @edad, @genero, @materias)";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@nombre", alumno.Nombre));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@edad", alumno.Edad));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@genero", alumno.Genero));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@materias", materias));

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
        public static int SelectIdMateria(Materia materia)
        {
            try
            {
                DBConexion.consulta.CommandText = "SELECT id FROM Materias WHERE nombre=@nombre AND turno=@turno";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@nombre", materia.Nombre));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@turno", materia.Turno.ToString()));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }
                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                int cargados = 0;
                while (datos.Read())
                {
                    cargados = int.Parse(datos["id"].ToString());
                }
                return cargados;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al encontrar el id de la materia.\n{ex.Message}"); ;
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
                DBConexion.consulta.CommandText = "INSERT INTO Materias VALUES(@nombre, @cantAlumnos, @turno, @alumnos)";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@nombre", materia.Nombre));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@cantAlumnos", materia.CantAlumnos));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@turno", materia.Turno.ToString()));
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
        public static int UptdateAlumnoAMaterias(Materia materia, int id)
        {
            try
            {
                DBConexion.consulta.CommandText = "UPDATE Materias SET alumnos=@alumnos WHERE id=@id";
                DBConexion.consulta.Parameters.Clear();
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

        public static int UpdateCantAlumnos(Materia materia)
        {
            try
            {
                DBConexion.consulta.CommandText = "UPDATE Materias SET cantAlumnos = @cantidad WHERE id=@id and cantAlumnos < @cantidad";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@id", materia.Id));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@cantidad", materia.CantAlumnos));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                return DBConexion.consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al actualizar la cantidad de la materia\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static string SelectTotalDe(string nombreObjeto, string parametro)
        {
            try
            {
                string retorno = "";
                string auxParametro = parametro;
                if (nombreObjeto.ToLower().Equals("alumno"))
                {
                    DBConexion.consulta.CommandText = "select count(@parametro) as total from Alumnos";
                } 
                else if (nombreObjeto.ToLower().Equals("materia"))
                {
                    DBConexion.consulta.CommandText = "select count(@parametro) as total from Materias";
                    if (parametro.Equals("cantidad de Alumnos"))
                    {
                        auxParametro = "cantAlumnos";
                    }
                } 
                else
                {
                    throw new Exception("No se ingresó una tabla valida.");
                }
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@parametro", auxParametro));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                while (datos.Read())
                {
                    retorno =  datos["total"].ToString();
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al calcular el total que busca.\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static List<string> SelectParametros(string nombreObjeto, string parametro)
        {
            try
            {
                List<string> retorno = new List<string>();
                string auxParametro = parametro;
                if (nombreObjeto.ToLower().Equals("alumnos"))
                {
                    DBConexion.consulta.CommandText = "declare @sql nvarchar(50) set @sql = 'select ' + @parametro + ' as resultado from Alumnos' exec(@sql)";
                }
                else if (nombreObjeto.ToLower().Equals("materias"))
                {
                    DBConexion.consulta.CommandText = "declare @sql nvarchar(50) set @sql = 'select ' + @parametro + ' as resultado from Materias' exec(@sql)";
                    if (parametro.ToLower().Equals("cantidad de alumnos"))
                    {
                        auxParametro = "cantAlumnos";
                    }
                }
                else
                {
                    throw new Exception("No se ingresó una tabla valida.");
                }
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@parametro", auxParametro));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();
                int index = 0;
                while (datos.Read())
                {
                    retorno.Add(datos["resultado"].ToString());
                    index++;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al buscar los parametros.\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static bool ConfirmarExistenciaAlumno(string id)
        {
            try
            {
                string retorno = "";
                DBConexion.consulta.CommandText = "select COUNT(*) as existe from Alumnos where id=@id";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@id", id));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                while (datos.Read())
                {
                    retorno = datos["existe"].ToString();
                }
                return int.Parse(retorno) == 1? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al calcular el total que busca.\n{ex.Message}"); ;
            }
            finally
            {
                if (miConexion.State != System.Data.ConnectionState.Closed)
                {
                    miConexion.Close();
                }
            }
        }
        public static bool ConfirmarExistenciaMateria(string materia, string turno)
        {
            try
            {
                string retorno = "";
                DBConexion.consulta.CommandText = "select COUNT(*) as existe from Materias where nombre=@materia AND turno=@turno";
                DBConexion.consulta.Parameters.Clear();
                DBConexion.consulta.Parameters.Add(new SqlParameter("@materia", materia));
                DBConexion.consulta.Parameters.Add(new SqlParameter("@turno", turno));

                if (miConexion.State != System.Data.ConnectionState.Open)
                {
                    miConexion.Open();
                }

                SqlDataReader datos = DBConexion.consulta.ExecuteReader();

                while (datos.Read())
                {
                    retorno = datos["existe"].ToString();
                }
                return int.Parse(retorno) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio un error al calcular el total que busca.\n{ex.Message}"); ;
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
