using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vistas.Controles;

namespace Vistas.Formulario
{
    public partial class frmDashboardPrincipal : Form
    {
        #region
        private Form activarForm = null;

        public void AbrirForm(Form formularioPintar)
        {
            string nombreFormulario = formularioPintar.GetType().Name;

            if (!ControlDeAcceso.TienePermiso(Modelos.Entidades.SesionActual.IdRol, nombreFormulario))
            {
                MessageBox.Show("No tienes permiso para acceder a este módulo.");
                return;
            }

            if (activarForm != null)
            {
                activarForm.Close();
            }

            activarForm = formularioPintar;
            formularioPintar.TopLevel = false;
            formularioPintar.FormBorderStyle = FormBorderStyle.None;
            formularioPintar.Dock = DockStyle.Fill;
            pnlPanelCentral.Controls.Add(formularioPintar);
            formularioPintar.BringToFront();
            formularioPintar.Show();
        }
        #endregion

        public frmDashboardPrincipal()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmPacientes());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
             AbrirForm(new frmHistorial());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDashboardPrincipal_Load(object sender, EventArgs e)
        {
            switch (Modelos.Entidades.SesionActual.IdRol)
            {
                case 1: // Administrador
                        // acceso total
                    break;
                case 2: // Medico
                    btnMedicos.Visible = false;
                    btnEspecialidades.Visible = false;
                   
                    break;
                case 3: // Recepcionista
                    btnMedicos.Visible = false;
                    btnHistorial.Visible = false;
                    btnEspecialidades.Visible = false;
                    break;
            }
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmMedicos());
        }

       

        private void btnCItas_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmCItas());
        }

        private void pnlPanelCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmEspecialidades());
        }
    }
}

