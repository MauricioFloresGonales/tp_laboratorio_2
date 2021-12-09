using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Entidades;

namespace FormApp
{
    public partial class FrmAnalizar : Form
    {
        public FrmAnalizar()
        {
            InitializeComponent();
        }

        private void FrmAnalizar_Load(object sender, EventArgs e)
        {
            this.cmbLista.Items.Add("materias");
            this.cmbLista.Items.Add("alumnos");

            this.cmbEstudio.Enabled = false;
            this.cmbParametro.Enabled = false;
        }
        private void cmbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbEstudio.Enabled = true;
                this.cmbEstudio.Items.Clear();
                this.cmbEstudio.Text = "";

                switch (cmbLista.Text)
                {
                    case "materias":
                        this.cmbEstudio.Items.Add("nombre");
                        this.cmbEstudio.Items.Add("cantidad de Alumnos");
                        this.cmbEstudio.Items.Add("turno");
                        break;
                    case "alumnos":
                        this.cmbEstudio.Items.Add("nombre");
                        this.cmbEstudio.Items.Add("edad");
                        this.cmbEstudio.Items.Add("genero");
                        this.cmbEstudio.Items.Add("materias");
                        break;
                    default:
                        throw new Exception($"{cmbLista.Text} no es un valor posible");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
        private void BuscarParametros(string estudio, string parametro)
        {
            try
            {
                this.Parametros(DBConexion.SelectParametros(estudio, parametro));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
        private void Parametros(List<string> opciones)
        {
            if (InvokeRequired)
            {
                Action<List<string>> delegado = Parametros;
                Invoke(delegado, opciones);
            }
            else
            { 
                foreach (string item in opciones)
                {
                    this.cmbParametro.Items.Add(item.Trim());
                }
            }
        }
        private void cmbEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmbParametro.Enabled = true;
                this.cmbParametro.Items.Clear();
                this.cmbParametro.Text = "";
                string estudio = cmbLista.Text;
                switch (estudio)
                {
                    case "materias":
                        switch (cmbEstudio.Text.ToLower())
                        {
                            case "nombre":
                            case "cantidad de alumnos":
                                this.lblParamretro.Text = "Ingrese Nombre a evaluar :";
                                Task hilo = Task.Run(() => this.BuscarParametros(estudio, "nombre"));
                                break;
                            case "turno":
                                this.lblParamretro.Text = "Ingrese Turno a evaluar :";
                                this.cmbParametro.Items.Add("mañana");
                                this.cmbParametro.Items.Add("tarde");
                                break;
                        }
                        break;
                    case "alumnos":
                        switch (this.cmbEstudio.Text)
                        {
                            case "nombre":
                                this.lblParamretro.Text = "Ingrese Nombre a evaluar :";
                                this.cmbParametro.Enabled = true;
                                Task hiloNombre = Task.Run(() => this.BuscarParametros(estudio, "nombre"));
                                break;
                            case "edad":
                                this.lblParamretro.Text = "Ingrese Edad a evaluar :";
                                this.cmbParametro.Enabled = true;
                                Task hiloEdad = Task.Run(() => this.BuscarParametros(estudio, "edad"));
                                break;
                            case "genero":
                                this.lblParamretro.Text = "Ingrese Genero a evaluar :";
                                this.cmbParametro.Items.Add("masculino");
                                this.cmbParametro.Items.Add("femenino");
                                break;
                            case "materias":
                                this.lblParamretro.Text = "Ingrese el parametro a evaluar :";
                                this.cmbParametro.Items.Add("total de materias");
                                this.cmbParametro.Items.Add("mayor concurrencia");
                                this.cmbParametro.Items.Add("menor concurrencia");
                                break;
                        }
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Encuesta aux = new Encuesta();
                aux.EventoBuscar += Buscar;
                aux.ComenzarABuscar(this.cmbLista.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error");
            }
        }
        private void Buscar(string nombreDeObjeto)
        {
            int resultado = 0;
            float porcentaje = 0;
            if (nombreDeObjeto == "materias")
            {
                Materia aux = new Materia();
                resultado = SistemaDeDatos.ResultadoDeAnalisis(aux, this.cmbEstudio.Text, this.cmbParametro.Text);
                porcentaje = SistemaDeDatos.ResultadoDeAnalisisEnPorcentajes(aux, SistemaDeDatos.AnalizarTotal(aux, this.cmbEstudio.Text), resultado);
            }
            if (nombreDeObjeto == "alumnos")
            {
                Alumnos aux = new Alumnos();
                resultado = SistemaDeDatos.ResultadoDeAnalisis(aux, this.cmbEstudio.Text, this.cmbParametro.Text);
                porcentaje = SistemaDeDatos.ResultadoDeAnalisisEnPorcentajes(aux, SistemaDeDatos.AnalizarTotal(aux, this.cmbEstudio.Text), resultado);
            }
            this.lblResultado.Text = $"El resultado es: {resultado}";
            this.lblPorcentaje.Text = $"Y el porsentaje es: {porcentaje}% del todal";
        }
    }
}
