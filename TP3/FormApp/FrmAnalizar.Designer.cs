
namespace FormApp
{
    partial class FrmAnalizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbLista = new System.Windows.Forms.ComboBox();
            this.cmbEstudio = new System.Windows.Forms.ComboBox();
            this.cmbParametro = new System.Windows.Forms.ComboBox();
            this.lblListaDe = new System.Windows.Forms.Label();
            this.lblEstudio = new System.Windows.Forms.Label();
            this.lblParamretro = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbLista
            // 
            this.cmbLista.FormattingEnabled = true;
            this.cmbLista.Location = new System.Drawing.Point(12, 25);
            this.cmbLista.Name = "cmbLista";
            this.cmbLista.Size = new System.Drawing.Size(139, 21);
            this.cmbLista.TabIndex = 0;
            this.cmbLista.SelectedIndexChanged += new System.EventHandler(this.cmbLista_SelectedIndexChanged);
            // 
            // cmbEstudio
            // 
            this.cmbEstudio.FormattingEnabled = true;
            this.cmbEstudio.Location = new System.Drawing.Point(157, 25);
            this.cmbEstudio.Name = "cmbEstudio";
            this.cmbEstudio.Size = new System.Drawing.Size(138, 21);
            this.cmbEstudio.TabIndex = 1;
            this.cmbEstudio.SelectedIndexChanged += new System.EventHandler(this.cmbEstudio_SelectedIndexChanged);
            // 
            // cmbParametro
            // 
            this.cmbParametro.FormattingEnabled = true;
            this.cmbParametro.Location = new System.Drawing.Point(301, 25);
            this.cmbParametro.Name = "cmbParametro";
            this.cmbParametro.Size = new System.Drawing.Size(135, 21);
            this.cmbParametro.TabIndex = 2;
            // 
            // lblListaDe
            // 
            this.lblListaDe.AutoSize = true;
            this.lblListaDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaDe.Location = new System.Drawing.Point(12, 9);
            this.lblListaDe.Name = "lblListaDe";
            this.lblListaDe.Size = new System.Drawing.Size(58, 15);
            this.lblListaDe.TabIndex = 3;
            this.lblListaDe.Text = "Lista De :";
            // 
            // lblEstudio
            // 
            this.lblEstudio.AutoSize = true;
            this.lblEstudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstudio.Location = new System.Drawing.Point(154, 9);
            this.lblEstudio.Name = "lblEstudio";
            this.lblEstudio.Size = new System.Drawing.Size(70, 15);
            this.lblEstudio.TabIndex = 4;
            this.lblEstudio.Text = "Estudio De:";
            // 
            // lblParamretro
            // 
            this.lblParamretro.AutoSize = true;
            this.lblParamretro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParamretro.Location = new System.Drawing.Point(298, 9);
            this.lblParamretro.Name = "lblParamretro";
            this.lblParamretro.Size = new System.Drawing.Size(71, 15);
            this.lblParamretro.TabIndex = 5;
            this.lblParamretro.Text = "Parametro :";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(50, 89);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(101, 20);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "Resultado: ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(442, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 21);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblPorcentaje.Location = new System.Drawing.Point(297, 89);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(105, 20);
            this.lblPorcentaje.TabIndex = 9;
            this.lblPorcentaje.Text = "Porcentaje :";
            // 
            // FrmAnalizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(524, 141);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblParamretro);
            this.Controls.Add(this.lblEstudio);
            this.Controls.Add(this.lblListaDe);
            this.Controls.Add(this.cmbParametro);
            this.Controls.Add(this.cmbEstudio);
            this.Controls.Add(this.cmbLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAnalizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAnalizar";
            this.Load += new System.EventHandler(this.FrmAnalizar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLista;
        private System.Windows.Forms.ComboBox cmbEstudio;
        private System.Windows.Forms.ComboBox cmbParametro;
        private System.Windows.Forms.Label lblListaDe;
        private System.Windows.Forms.Label lblEstudio;
        private System.Windows.Forms.Label lblParamretro;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblPorcentaje;
    }
}