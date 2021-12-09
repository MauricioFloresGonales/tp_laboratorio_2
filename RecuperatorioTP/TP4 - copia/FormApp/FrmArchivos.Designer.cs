
namespace FormApp
{
    partial class FrmArchivos
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
            this.btnAnalisisAlumnos = new System.Windows.Forms.Button();
            this.btnAnalisisMaterias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAnalisisAlumnos
            // 
            this.btnAnalisisAlumnos.Location = new System.Drawing.Point(12, 12);
            this.btnAnalisisAlumnos.Name = "btnAnalisisAlumnos";
            this.btnAnalisisAlumnos.Size = new System.Drawing.Size(231, 71);
            this.btnAnalisisAlumnos.TabIndex = 0;
            this.btnAnalisisAlumnos.Text = "Imprimir Analisis Alumnos";
            this.btnAnalisisAlumnos.UseVisualStyleBackColor = true;
            this.btnAnalisisAlumnos.Click += new System.EventHandler(this.btnAnalisisAlumnos_Click);
            // 
            // btnAnalisisMaterias
            // 
            this.btnAnalisisMaterias.Location = new System.Drawing.Point(14, 89);
            this.btnAnalisisMaterias.Name = "btnAnalisisMaterias";
            this.btnAnalisisMaterias.Size = new System.Drawing.Size(229, 71);
            this.btnAnalisisMaterias.TabIndex = 1;
            this.btnAnalisisMaterias.Text = "Imprimir Analisis Materias";
            this.btnAnalisisMaterias.UseVisualStyleBackColor = true;
            this.btnAnalisisMaterias.Click += new System.EventHandler(this.btnAnalisisMaterias_Click);
            // 
            // FrmArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(255, 170);
            this.Controls.Add(this.btnAnalisisMaterias);
            this.Controls.Add(this.btnAnalisisAlumnos);
            this.Name = "FrmArchivos";
            this.Text = "FrmArchivos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAnalisisAlumnos;
        private System.Windows.Forms.Button btnAnalisisMaterias;
    }
}