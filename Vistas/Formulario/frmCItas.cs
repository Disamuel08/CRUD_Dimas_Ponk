using Modelos;
using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Vistas.Formulario
{
    public partial class frmCItas : Form
    {
        public frmCItas()
        {
            InitializeComponent();
        }

        private void lblIdCliente_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1 ||  string.IsNullOrEmpty(txtHora.Text))
            {
                MessageBox.Show("Hay campos vacios");
                return;
            }

            if (!ValidarHora(txtHora.Text.Trim()))
            {
                MessageBox.Show(" El formato de la hora no es válido.\nEjemplo correcto: 08:30 o 14:45");
                txtHora.Focus();
                txtHora.SelectAll();
                return;
            }

            Cita p = new Cita();
            p.Id_cliente = Convert.ToInt32(cmbCliente.SelectedValue);
           
            p.Fecha = dtpFecha.Value;
            p.Hora = TimeSpan.Parse(txtHora.Text);

            p.InsertarCita();
            dgvCitas.DataSource = Cita.MostrarCitas();

            dtgvCitas2.DataSource = Cita.MostrarCitas();

            txtHora.Clear();
            cmbCliente.SelectedIndex = -1;
         


        }

        private bool ValidarHora(string hora)
        {
            string patron = @"^(?:[01]?\d|2[0-3]):[0-5]\d$";
            return System.Text.RegularExpressions.Regex.IsMatch(hora, patron);
        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
