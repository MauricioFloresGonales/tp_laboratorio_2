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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            SistemaDeDatos.HardCodeoDeDatos();
        }

        private void btnAnalizarDatos_Click(object sender, EventArgs e)
        {
            FrmAnalizar frmAnalizar = new FrmAnalizar();
            Task hilo = Task.Run(() => {
                if (frmAnalizar.ShowDialog() == DialogResult.OK){ }
            });
        }

        private void btnCrearDatos_Click(object sender, EventArgs e)
        {
            FrmCrearEncuesta frmCrearEncuesta = new FrmCrearEncuesta();
            Task hilo = Task.Run(() => {
                if (frmCrearEncuesta.ShowDialog() == DialogResult.OK){ }
            });
        }
        private void btnArchivos_Click(object sender, EventArgs e)
        {
            FrmArchivos frmArchivos = new FrmArchivos();
            Task hilo = Task.Run(() => {
            if (frmArchivos.ShowDialog() == DialogResult.OK) { }
            });
        }
    }
}
