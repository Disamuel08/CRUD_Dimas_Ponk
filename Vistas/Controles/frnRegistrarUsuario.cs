using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Controles
{
    public partial class frnRegistrarUsuario : UserControl
    {
        public frnRegistrarUsuario()
        {
            InitializeComponent();
            this.Load += frnRegistrarUsuario_Load;
            txtNombreUsuario.MaxLength = 100;
            txtClave.MaxLength = 100;
         

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void frnIniciarSesion2_Load(object sender, EventArgs e)
        {
           
            // Inicializar placeholders
            txtNombreUsuario.Text = "Usuario";
            txtNombreUsuario.ForeColor = Color.Black;

            txtClave.Text = "Contraseña";
            txtClave.ForeColor = Color.Black;
            txtClave.UseSystemPasswordChar = false; // Mostrar texto plano para placeholder


        
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

      
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void frnRegistrarUsuario_Load(object sender, EventArgs e)
        {
            cargarRoles();
            txtNombreUsuario.MaxLength = 50;
            txtClave.MaxLength = 50;
  
        }

        private void cargarRoles()
        {
            cmbRoles.DataSource = null;
            cmbRoles.DataSource = Usuario.cargarRoles();
            cmbRoles.DisplayMember = "nombre_Rol";
            cmbRoles.ValueMember = "id_Rol";
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                //string correo = txtCorreo.Text.Trim();
                //if (!ValidacionCorreo(correo))
                //{
                //    MessageBox.Show("El formato del correo electrónico no es válido", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtCorreo.Focus();
                //    txtCorreo.SelectAll();
                //    return;
                //}
                Usuario user = new Usuario();
                user.Nombre_Usuario = txtNombreUsuario.Text;
                user.Clave = BCrypt.Net.BCrypt.HashPassword(txtClave.Text);
                user.Id_Rol = Convert.ToInt32(cmbRoles.SelectedValue);
                if (user.RegistrarUsuario() == true)
                {
                    MessageBox.Show("Usuario registrado:Bienvenido " + user.Nombre_Usuario);
                }
            }
        }

        //private bool ValidacionCorreo(string correo)
        //{
        //    // Expresión regular para formato de correo
        //    string patron = @"^[a-zA-Z0-9._\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z]{2,}$";
        //    return Regex.IsMatch(correo, patron);
        //}

        //private void txtCorreo_TextChanged(object sender, EventArgs e)
        //{
        //    // Permitir solo caracteres válidos en correos
        //    string texto = txtCorreo.Text;
        //    string limpio = Regex.Replace(texto, @"[^a-zA-Z0-9@._\-]", "");

        //    if (texto != limpio)
        //    {
        //        int pos = txtCorreo.SelectionStart - 1;
        //        txtCorreo.Text = limpio;
        //        txtCorreo.SelectionStart = Math.Max(0, pos);
        //    }
        //}

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
