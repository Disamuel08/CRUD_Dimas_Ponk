namespace Vistas.Formulario
{
    partial class frmDashboardPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnCItas = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.pnlPanelCentral = new System.Windows.Forms.Panel();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnEspecialidades);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnHistorial);
            this.panel1.Controls.Add(this.btnCItas);
            this.panel1.Controls.Add(this.btnMedicos);
            this.panel1.Controls.Add(this.btnPacientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 446);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(0, 400);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(200, 46);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Location = new System.Drawing.Point(0, 161);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(200, 61);
            this.btnHistorial.TabIndex = 4;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnCItas
            // 
            this.btnCItas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCItas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCItas.Location = new System.Drawing.Point(0, 107);
            this.btnCItas.Name = "btnCItas";
            this.btnCItas.Size = new System.Drawing.Size(200, 54);
            this.btnCItas.TabIndex = 3;
            this.btnCItas.Text = "CItas";
            this.btnCItas.UseVisualStyleBackColor = true;
            this.btnCItas.Click += new System.EventHandler(this.btnCItas_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Location = new System.Drawing.Point(0, 52);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(200, 55);
            this.btnMedicos.TabIndex = 2;
            this.btnMedicos.Text = "Medicos";
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Location = new System.Drawing.Point(0, 0);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(200, 52);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // pnlPanelCentral
            // 
            this.pnlPanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanelCentral.Location = new System.Drawing.Point(200, 0);
            this.pnlPanelCentral.Name = "pnlPanelCentral";
            this.pnlPanelCentral.Size = new System.Drawing.Size(600, 446);
            this.pnlPanelCentral.TabIndex = 1;
            this.pnlPanelCentral.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPanelCentral_Paint);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecialidades.Location = new System.Drawing.Point(0, 222);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(200, 61);
            this.btnEspecialidades.TabIndex = 6;
            this.btnEspecialidades.Text = "Especialidades";
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            // 
            // frmDashboardPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 446);
            this.Controls.Add(this.pnlPanelCentral);
            this.Controls.Add(this.panel1);
            this.Name = "frmDashboardPrincipal";
            this.Text = "DashboardPrincipal";
            this.Load += new System.EventHandler(this.frmDashboardPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnCItas;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Panel pnlPanelCentral;
        private System.Windows.Forms.Button btnEspecialidades;
    }
}