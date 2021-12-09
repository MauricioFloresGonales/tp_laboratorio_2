using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormApp
{
    public delegate void DelegadoBacklog(string text);
    public partial class FrmArchivos : Form
    {
        public FrmArchivos()
        {
            InitializeComponent();
        }
        private void IniciarFuncion(string text)
        {
            Archivos.GenerarAnalisis(SistemaDeDatos.ListaDeAlumnos, text);
        }

        private void btnAnalisisAlumnos_Click(object sender, EventArgs e)
        {
            try
            {
                Task hilo = Task.Run(() => Archivos.GenerarAnalisis(SistemaDeDatos.ListaDeAlumnos, "Alumnos.txt"));
                Task hilo1 = Task.Run(() => Archivos.GenerarJson(SistemaDeDatos.ListaDeAlumnos, "Alumnos.txt"));
                Task hilo2 = Task.Run(() => Archivos.GenerarXML(SistemaDeDatos.ListaDeAlumnos, "Alumnos.txt"));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnAnalisisMaterias_Click(object sender, EventArgs e)
        {
            try
            {
                Task hilo = Task.Run(() => Archivos.GenerarAnalisis(SistemaDeDatos.ListaDeMaterias, "Materias.txt"));
                Task hilo1 = Task.Run(() => Archivos.GenerarJson(SistemaDeDatos.ListaDeMaterias, "Materias.txt"));
                Task hilo2 = Task.Run(() => Archivos.GenerarXML(SistemaDeDatos.ListaDeMaterias, "Materias.txt"));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
