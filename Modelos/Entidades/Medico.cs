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
    public class Medico
    {
        private int id_Medico;
        private string nombre_Medico;
        private int id_Especialidad;
        private string telefono;

        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public string Nombre_Medico { get => nombre_Medico; set => nombre_Medico = value; }
        public int Id_Especialidad { get => id_Especialidad; set => id_Especialidad = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public static DataTable MostrarMedicos()
        {
            SqlConnection con = Conexion.Conexion.Conectar();
            string comando = "SELECT    m.id_Medico,   m.nombre_Medico,    e.nombre_Especialidad AS especialidad,    m.telefono FROM Medicos m INNER JOIN Especialidades e ON m.id_Especialidad = e.id_Especialidad;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public bool InsertarMedico()
        {
            try
            {
                SqlConnection con = Conexion.Conexion.Conectar();

                string comando = "INSERT INTO Medicos (nombre_Medico, id_Especialidad, telefono) values (@nombre_Medico, @id_Especialidad, @telefono);";

                SqlCommand cmd = new SqlCommand(comando, con);

                cmd.Parameters.AddWithValue("@nombre_Medico", nombre_Medico);
                cmd.Parameters.AddWithValue("@id_Especialidad", id_Especialidad);
                cmd.Parameters.AddWithValue("@telefono",telefono);

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

        public bool eliminarMedico(int id)
        {
            try
            {
                SqlConnection conectar = Conexion.Conexion.Conectar();
                string consultaDelete = "Delete from Medicos where id_Medico=@id_Medico";
                SqlCommand delete = new SqlCommand(consultaDelete, conectar);
                delete.Parameters.AddWithValue("@id_Medico", id);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool actualizarMedico()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaUpdate = "update Medicos set nombre_Medico=@nombre_Medico, id_Especialidad=@id_Especialidad, telefono=@telefono where id_Medico=@id_Medico";
                SqlCommand update = new SqlCommand(consultaUpdate, conexion);

                update.Parameters.AddWithValue("@nombre_Medico", nombre_Medico);
                update.Parameters.AddWithValue("@id_Especialidad", id_Especialidad);
                update.Parameters.AddWithValue("@telefono", telefono);
                update.Parameters.AddWithValue("@id_Medico", id_Medico);

                update.ExecuteNonQuery();
                MessageBox.Show("Medico actualizado exitosamente.", "Actualización Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica si la consulta de actualizar esta correcta " + ex, "Error");
                return false;
            }
        }

        public static DataTable BuscarMedico(string busqueda)
        {
            SqlConnection con = Conexion.Conexion.Conectar();

            string comando = @"SELECT 
                             m.id_Medico,
                             m.nombre_Medico,
                             e.nombre_Especialidad AS especialidad,
                             m.telefono
                             FROM Medicos m
                             INNER JOIN Especialidades e ON m.id_Especialidad = e.id_Especialidad
                             WHERE m.nombre_Medico LIKE '%' + @busqueda + '%' 
                             OR e.nombre_Especialidad LIKE '%' + @busqueda + '%';";

            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
