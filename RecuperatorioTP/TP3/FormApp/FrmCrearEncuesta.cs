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
    public partial class FrmCrearEncuesta : Form
    {
        Stack<Materia> materias;
        public FrmCrearEncuesta()
        {
            InitializeComponent();
        }

        private void rbtnMateria_CheckedChanged(object sender, EventArgs e)
        {
            this.gboxMaterias.Visible = false;
        }

        private void rbtnAlumno_CheckedChanged(object sender, EventArgs e)
        {
            this.gboxMaterias.Visible = true;
            materias = new Stack<Materia>();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnMateria.Checked)
                {
                    Materia auxMateria = new Materia(this.txtNombre.Text, Materia.AnalisisDeTurnos(this.cmbTurno.Text));
                    SistemaDeDatos.AgregarMateria(auxMateria);
                    DBConexion.InsertMaterias(auxMateria);
                }
                if (this.rbtnAlumno.Checked)
                {
                    List<Materia> aux = new List<Materia>();
                    foreach (Materia item in materias)
                    {
                        aux.Add(item);
                    }
                    Alumnos nuevoAlumno = SistemaDeDatos.AgregarAlumnoAMateria(new Alumnos(this.txtNombre.Text, int.Parse(this.txtEdad.Text), this.cmbGenero.Text, aux));
                    SistemaDeDatos.AgregarAlumno(nuevoAlumno);
                    DBConexion.InsertAlumnos(nuevoAlumno);
                    foreach (Materia item in nuevoAlumno.Materias)
                    {
                        DBConexion.InsertAlumnoAMaterias(item, nuevoAlumno.Id);
                    }
                    
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = "";
            this.cmbTurno.Text = "";
            this.txtEdad.Text = "";
            this.cmbGenero.Text = "";
            this.cmbMateria.Text = "";
            this.lstMaterias.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            materias.Push(new Materia(this.cmbMateria.Text, Materia.AnalisisDeTurnos(this.cmbTurno.Text)));

            this.lstMaterias.Text = "";
            foreach (Materia item in materias)
            {
                this.lstMaterias.Items.Add(item.Nombre.ToString());
            }
        }
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            materias.Pop();
        }
    }
}
