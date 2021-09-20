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

namespace MiCaluculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void FormCalculadora_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (
                MessageBox.Show(
                "Estas seguro que quiere salir?",
                "SALIR",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2) == DialogResult.No
               )
            {
                e.Cancel = true;
            }
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            char opertador = this.cmbOperadores.Text[0];
            double result = Calculadora.Operar(
                new Operando(this.txtNumeroUno.Text), 
                new Operando(this.txtNumeroDos.Text),
                opertador);
            this.lblResultado.Text = result.ToString();
            this.lstOperaciones.Text = $"{this.txtNumeroUno.Text} {this.cmbOperadores.Text[0]} {this.txtNumeroDos.Text} = {this.lblResultado.Text}";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            this.txtNumeroUno.Text = "";
            this.txtNumeroDos.Text = "";
            this.lblResultado.Text = "0";
            this.cmbOperadores.Text = " ";
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operador[0]);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
        }
    }
}
