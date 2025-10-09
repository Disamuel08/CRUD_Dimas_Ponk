using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos
{
    public class Especialidad
    {
        private int id_Especialidad;
        private string nombre_Especialidad;

        public int Id_Especialidad { get => id_Especialidad; set => id_Especialidad = value; }
        public string Nombre_Especialidad { get => nombre_Especialidad; set => nombre_Especialidad = value; }

        public static DataTable MostrarEspecialidad()
        {
            SqlConnection con = Conexion.Conexion.Conectar();
            string comando = "SELECT * FROM especialidad;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public bool InsertarEspecialidad()
        {
            try
            {
                SqlConnection con = Conexion.Conexion.Conectar();

                string comando = "Insert into especialidad (nombre_Especialidad) " +
                    " values (@nombre_Especialidad);";

                SqlCommand cmd = new SqlCommand(comando, con);

                cmd.Parameters.AddWithValue("@id_Paciente", nombre_Especialidad);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool eliminarEspecialidad(int id)
        {
            try
            {
                SqlConnection conectar = Conexion.Conexion.Conectar();
                string consultaDelete = "Delete from especialidad where id_Especialidad=@id_Especialidad";
                SqlCommand delete = new SqlCommand(consultaDelete, conectar);
                delete.Parameters.AddWithValue("@id_Especialidad", id);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool actualizarEspecialidad()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaUpdate = "update cita set nombre_Especialidad=@nombre_Especialidad  where  id_Especialidad=@id_Especialidad";
                SqlCommand update = new SqlCommand(consultaUpdate, conexion);

                update.Parameters.AddWithValue("@id_Especialidad", id_Especialidad);
                update.Parameters.AddWithValue("@nombre_Especialidad", nombre_Especialidad);

                update.ExecuteNonQuery();
                MessageBox.Show("Especialidad actualizada exitosamente.", "Actualización Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica si la consulta de actualizar esta correcta " + ex, "Error");
                return false;
            }
        }

        public static DataTable BuscarEspecialidad(string busqueda)
        {
            SqlConnection con = Conexion.Conexion.Conectar();

            string comando = @"";

            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
