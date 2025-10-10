using Modelos;
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
    public partial class frmEspecialidades : Form
    {
        public frmEspecialidades()
        {
            InitializeComponent();
            CargarTablaEspecialidad();
            txtNombreEspecialidad.MaxLength = 50;
        }

        private void CargarTablaEspecialidad()
        {
            dgvEspecialidades.DataSource = null;
            dgvEspecialidades.DataSource = Especialidad.MostrarEspecialidad();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmEspecialidades_Load(object sender, EventArgs e)
        {
            CargarTablaEspecialidad();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                Especialidad p = new Especialidad();
                p.Nombre_Especialidad = txtNombreEspecialidad.Text;

                p.InsertarEspecialidad();
                dgvEspecialidades.DataSource = Especialidad.MostrarEspecialidad();
                txtNombreEspecialidad.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Especialidad especialidadEliminar = new Especialidad();
            int id = int.Parse(dgvEspecialidades.CurrentRow.Cells[0].Value.ToString());
            string registroEliminar = dgvEspecialidades.CurrentRow.Cells[1].Value.ToString();

            DialogResult respuesta = MessageBox.Show($"¿Estás seguro de eliminar el registro: {registroEliminar}?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                if (especialidadEliminar.eliminarEspecialidad(id))
                {
                    MessageBox.Show("Registro eliminado exitosamente.", "Eliminación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaEspecialidad();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                Especialidad es = new Especialidad();
                es.Nombre_Especialidad = txtNombreEspecialidad.Text;
                es.Id_Especialidad= int.Parse(dgvEspecialidades.CurrentRow.Cells[0].Value.ToString());
                if (es.actualizarEspecialidad() == true)
                {
                    MessageBox.Show("Registro Actualizado exitosamente.", "Actualizacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaEspecialidad();
                    txtNombreEspecialidad.Clear();
                }
                else
                {
                    MessageBox.Show("Error al Actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvEspecialidades.DataSource = Especialidad.BuscarEspecialidad(txtBuscar.Text);
        }
    }
}
