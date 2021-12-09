
namespace FormApp
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrearDatos = new System.Windows.Forms.Button();
            this.btnAnalizarDatos = new System.Windows.Forms.Button();
            this.btnArchivos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearDatos
            // 
            this.btnCrearDatos.Location = new System.Drawing.Point(12, 12);
            this.btnCrearDatos.Name = "btnCrearDatos";
            this.btnCrearDatos.Size = new System.Drawing.Size(166, 65);
            this.btnCrearDatos.TabIndex = 0;
            this.btnCrearDatos.Text = "Crear Datos";
            this.btnCrearDatos.UseVisualStyleBackColor = true;
            this.btnCrearDatos.Click += new System.EventHandler(this.btnCrearDatos_Click);
            // 
            // btnAnalizarDatos
            // 
            this.btnAnalizarDatos.Location = new System.Drawing.Point(12, 83);
            this.btnAnalizarDatos.Name = "btnAnalizarDatos";
            this.btnAnalizarDatos.Size = new System.Drawing.Size(166, 65);
            this.btnAnalizarDatos.TabIndex = 1;
            this.btnAnalizarDatos.Text = "Analizar Datos";
            this.btnAnalizarDatos.UseVisualStyleBackColor = true;
            this.btnAnalizarDatos.Click += new System.EventHandler(this.btnAnalizarDatos_Click);
            // 
            // btnArchivos
            // 
            this.btnArchivos.Location = new System.Drawing.Point(12, 154);
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(166, 65);
            this.btnArchivos.TabIndex = 3;
            this.btnArchivos.Text = "Archivos";
            this.btnArchivos.UseVisualStyleBackColor = true;
            this.btnArchivos.Click += new System.EventHandler(this.btnArchivos_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(187, 230);
            this.Controls.Add(this.btnArchivos);
            this.Controls.Add(this.btnAnalizarDatos);
            this.Controls.Add(this.btnCrearDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisis De Datos - Alumnos y Materias";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearDatos;
        private System.Windows.Forms.Button btnAnalizarDatos;
        private System.Windows.Forms.Button btnArchivos;
    }
}

