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

namespace Vistas
{
    public partial class login : Form
    {

        frnRegistrarUsuario frmRegistarUsuario = new frnRegistrarUsuario();
        InicioSesion2 frmIniciarSesion = new InicioSesion2();

        public login()
        {
            InitializeComponent();
        }
            private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(frmIniciarSesion);
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(frmRegistarUsuario);
        }

        private void login_Load(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(frmIniciarSesion);
        }
    }
}
