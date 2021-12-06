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
        Stack<Materia> stackMaterias;
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
            stackMaterias = new Stack<Materia>();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnMateria.Checked)
                {
                    Materia auxMateria = new Materia(this.txtNombre.Text, Materia.AnalisisDeTurnos(this.cmbTurno.Text));
                    SistemaDeDatos.AgregarMateria(auxMateria);
                }
                if (this.rbtnAlumno.Checked)
                {
                    List<Materia> aux = new List<Materia>();
                    foreach (Materia item in stackMaterias)
                    {
                        aux.Add(item);
                    }
                    Alumnos nuevoAlumno = SistemaDeDatos.AgregarAlumnoAMateria(new Alumnos(this.txtNombre.Text, int.Parse(this.txtEdad.Text), this.cmbGenero.Text, aux));
                    SistemaDeDatos.AgregarAlumno(nuevoAlumno);
                    foreach (Materia item in nuevoAlumno.Materias)
                    {
                        DBConexion.UptdateAlumnoAMaterias(item, nuevoAlumno.Id);
                    }
                }
                this.Limpiar();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void Limpiar()
        {
            this.txtNombre.Text = "";
            this.cmbTurno.Text = "";
            this.txtEdad.Text = "";
            this.cmbGenero.Text = "";
            this.cmbMateria.Text = "";
            this.rtxMaterias.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                stackMaterias.Push(new Materia(this.cmbMateria.Text, Materia.AnalisisDeTurnos(this.cmbTurno.Text)));

                this.mostrarStacMaterias(stackMaterias);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }
        private void mostrarStacMaterias(Stack<Materia> materias)
        {
            this.cmbMateria.Text = "";
            this.cmbMateria.SelectedItem = null;
            this.rtxMaterias.Text = "";
            this.rtxMaterias.Text = materias.Formato();
        }
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            stackMaterias.Pop();
            this.mostrarStacMaterias(stackMaterias);
        }

        private void FrmCrearEncuesta_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string item in DBConexion.SelectParametros("materias", "nombre"))
                {
                    this.cmbMateria.Items.Add(item.Trim());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
