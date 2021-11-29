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
    public partial class FrmArchivos : Form
    {
        public FrmArchivos()
        {
            InitializeComponent();
        }

        private void btnAnalisisAlumnos_Click(object sender, EventArgs e)
        {
            try
            {

                Archivos.GenerarAnalisis(SistemaDeDatos.ListaDeAlumnos, "Alumnos.txt");
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
                Archivos.GenerarAnalisis(SistemaDeDatos.ListaDeMaterias, "Materias.txt");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
