
namespace FormApp
{
    partial class FrmCrearEncuesta
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
            this.rbtnMateria = new System.Windows.Forms.RadioButton();
            this.rbtnAlumno = new System.Windows.Forms.RadioButton();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblMaterias = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRetirar = new System.Windows.Forms.Button();
            this.gboxMaterias = new System.Windows.Forms.GroupBox();
            this.rtxMaterias = new System.Windows.Forms.RichTextBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.gboxMaterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnMateria
            // 
            this.rbtnMateria.AutoSize = true;
            this.rbtnMateria.Location = new System.Drawing.Point(47, 12);
            this.rbtnMateria.Name = "rbtnMateria";
            this.rbtnMateria.Size = new System.Drawing.Size(60, 17);
            this.rbtnMateria.TabIndex = 0;
            this.rbtnMateria.TabStop = true;
            this.rbtnMateria.Text = "Materia";
            this.rbtnMateria.UseVisualStyleBackColor = true;
            this.rbtnMateria.CheckedChanged += new System.EventHandler(this.rbtnMateria_CheckedChanged);
            // 
            // rbtnAlumno
            // 
            this.rbtnAlumno.AutoSize = true;
            this.rbtnAlumno.Location = new System.Drawing.Point(113, 12);
            this.rbtnAlumno.Name = "rbtnAlumno";
            this.rbtnAlumno.Size = new System.Drawing.Size(60, 17);
            this.rbtnAlumno.TabIndex = 1;
            this.rbtnAlumno.TabStop = true;
            this.rbtnAlumno.Text = "Alumno";
            this.rbtnAlumno.UseVisualStyleBackColor = true;
            this.rbtnAlumno.CheckedChanged += new System.EventHandler(this.rbtnAlumno_CheckedChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(9, 51);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(63, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre :";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(23, 77);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(49, 16);
            this.lblTurno.TabIndex = 3;
            this.lblTurno.Text = "Turno :";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.Location = new System.Drawing.Point(22, 7);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(47, 16);
            this.lblEdad.TabIndex = 4;
            this.lblEdad.Text = "Edad :";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(10, 33);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(59, 16);
            this.lblGenero.TabIndex = 5;
            this.lblGenero.Text = "Género :";
            // 
            // lblMaterias
            // 
            this.lblMaterias.AutoSize = true;
            this.lblMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterias.Location = new System.Drawing.Point(5, 60);
            this.lblMaterias.Name = "lblMaterias";
            this.lblMaterias.Size = new System.Drawing.Size(66, 16);
            this.lblMaterias.TabIndex = 6;
            this.lblMaterias.Text = "Materias :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(78, 51);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(116, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // cmbTurno
            // 
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Items.AddRange(new object[] {
            "mañana",
            "tarde"});
            this.cmbTurno.Location = new System.Drawing.Point(78, 77);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(116, 21);
            this.cmbTurno.TabIndex = 8;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(77, 6);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(116, 20);
            this.txtEdad.TabIndex = 9;
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "masculino",
            "femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(77, 32);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(116, 21);
            this.cmbGenero.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(9, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(60, 28);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRetirar
            // 
            this.btnRetirar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirar.Location = new System.Drawing.Point(8, 151);
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Size = new System.Drawing.Size(60, 26);
            this.btnRetirar.TabIndex = 14;
            this.btnRetirar.Text = "-";
            this.btnRetirar.UseVisualStyleBackColor = true;
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
            // 
            // gboxMaterias
            // 
            this.gboxMaterias.Controls.Add(this.rtxMaterias);
            this.gboxMaterias.Controls.Add(this.txtEdad);
            this.gboxMaterias.Controls.Add(this.cmbGenero);
            this.gboxMaterias.Controls.Add(this.lblEdad);
            this.gboxMaterias.Controls.Add(this.lblGenero);
            this.gboxMaterias.Controls.Add(this.cmbMateria);
            this.gboxMaterias.Controls.Add(this.btnRetirar);
            this.gboxMaterias.Controls.Add(this.btnAgregar);
            this.gboxMaterias.Controls.Add(this.lblMaterias);
            this.gboxMaterias.Location = new System.Drawing.Point(1, 104);
            this.gboxMaterias.Name = "gboxMaterias";
            this.gboxMaterias.Size = new System.Drawing.Size(218, 215);
            this.gboxMaterias.TabIndex = 15;
            this.gboxMaterias.TabStop = false;
            // 
            // rtxMaterias
            // 
            this.rtxMaterias.Location = new System.Drawing.Point(77, 87);
            this.rtxMaterias.Name = "rtxMaterias";
            this.rtxMaterias.Size = new System.Drawing.Size(135, 122);
            this.rtxMaterias.TabIndex = 15;
            this.rtxMaterias.Text = "";
            // 
            // cmbMateria
            // 
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(77, 59);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(116, 21);
            this.cmbMateria.TabIndex = 11;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(9, 325);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(98, 28);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(113, 325);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 28);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmCrearEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(219, 364);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.gboxMaterias);
            this.Controls.Add(this.cmbTurno);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.rbtnAlumno);
            this.Controls.Add(this.rbtnMateria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCrearEncuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearEncuesta";
            this.Load += new System.EventHandler(this.FrmCrearEncuesta_Load);
            this.gboxMaterias.ResumeLayout(false);
            this.gboxMaterias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnMateria;
        private System.Windows.Forms.RadioButton rbtnAlumno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblMaterias;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.GroupBox gboxMaterias;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.RichTextBox rtxMaterias;
    }
}