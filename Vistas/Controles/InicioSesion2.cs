using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vistas.Formulario;


namespace Vistas.Controles
{
    public partial class InicioSesion2 : UserControl
    {
        public InicioSesion2()
        {
            InitializeComponent();
            this.Load += frnIniciarSesion_Load;
            txtNombreUsuario.MaxLength = 100;
            txtClave.MaxLength = 100;
        }

        private void frnIniciarSesion_Load(object sender, EventArgs e)
        {
            // Inicializar placeholders
            txtNombreUsuario.Text = "Usuario";
            txtNombreUsuario.ForeColor = Color.Black;

            txtClave.Text = "Contraseña";
            txtClave.ForeColor = Color.Black;
            txtClave.UseSystemPasswordChar = false; // Mostrar texto plano para placeholder
            ;

        }

        private void txtNombreUsuario_Enter(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "Usuario")
            {
                txtNombreUsuario.Text = "";
                txtNombreUsuario.ForeColor = Color.Black;
            }
        }

        private void txtNombreUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                txtNombreUsuario.Text = "Usuario";
                txtNombreUsuario.ForeColor = Color.Black;
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Contraseña")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
                txtClave.UseSystemPasswordChar = true; // Activar ocultamiento al escribir
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                txtClave.Text = "Contraseña";
                txtClave.ForeColor = Color.Black;
                txtClave.UseSystemPasswordChar = false; // Mostrar texto plano para placeholder
            }
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtClave.Text)))
            {
                string clave = txtClave.Text;
                string nombre_Usuario = txtNombreUsuario.Text;

                Modelos.Entidades.Usuario usuario = new Modelos.Entidades.Usuario();
                if (usuario.VerificarLogin(nombre_Usuario, clave))
                {
                    // Guardar datos de sesión
                    Modelos.Entidades.SesionActual.NombreUsuario = nombre_Usuario;
                    Modelos.Entidades.SesionActual.IdRol = usuario.ObtenerRol(nombre_Usuario); // Método que debes implementar

                    MessageBox.Show("Inicio de sesión exitoso");
                    frmDashboardPrincipal dashboard = new frmDashboardPrincipal();
                    dashboard.Show();
                    Form parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Por favor llena los campos requeridos");
            }
        }

        

        private void InicioSesion2_Load(object sender, EventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
