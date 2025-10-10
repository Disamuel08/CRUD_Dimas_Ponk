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
            if (cmbCliente.SelectedIndex == -1 || cmbMedico.SelectedIndex == -1 ||  string.IsNullOrEmpty(txtHora.Text))
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
            p.Id_Paciente = Convert.ToInt32(cmbCliente.SelectedValue);
            p.Id_Medico = Convert.ToInt32(cmbMedico.SelectedValue);
            p.Fecha = dtpFecha.Value;
            p.Hora = TimeSpan.Parse(txtHora.Text);
            p.Motivo = txtDescripcion.Text;

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

        private void CargarTablaCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = Cita.MostrarCitas();

            dtgvCitas2.DataSource = null;
            dtgvCitas2.DataSource = Cita.MostrarCitas();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCItas_Load(object sender, EventArgs e)
        {
            CargarTablaCitas();
            cargarPacientes();
            cargarMedicos();
            cmbCliente.SelectedIndex = -1;
            dtpFecha.MinDate = DateTime.Today.AddDays(1);
            cmbCliente2.SelectedIndex = -1;
            cmbServicio2.SelectedIndex = -1;
            dtpFecha2.MinDate = DateTime.Today.AddDays(1);
            txtHora.MaxLength = 5;
            txtHora2.MaxLength = 5;
        }

        private void cargarPacientes()
        {
            //hay que poner la propiedad para que no escriban en los combo box
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = Cita.CargarPaciente();
            cmbCliente.DisplayMember = "nombre_Paciente";
            cmbCliente.ValueMember = "id_Paciente";

            cmbCliente2.DataSource = null;
            cmbCliente2.DataSource = Cita.CargarPaciente();
            cmbCliente2.DisplayMember = "nombre_Paciente";
            cmbCliente2.ValueMember = "id_Paciente";
        }

        private void cargarMedicos()
        {
            //hay que poner la propiedad para que no escriban en los combo box
            cmbMedico.DataSource = null;
            cmbMedico.DataSource = Cita.CargarMedicos();
            cmbMedico.DisplayMember = "nombre_Medico";
            cmbMedico.ValueMember = "id_Medico";

            cmbCliente2.DataSource = null;
            cmbCliente2.DataSource = Cita.CargarMedicos();
            cmbCliente2.DisplayMember = "nombre_Medico";
            cmbCliente2.ValueMember = "id_Medico";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
