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
    internal class Historial
    {
        private int id_Historial;
        private int id_Paciente;
        private int id_Medico;
        private string descripcion;
        private TimeSpan fecha;

        public int Id_Historial { get => id_Historial; set => id_Historial = value; }
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public TimeSpan Fecha { get => fecha; set => fecha = value; }

        public static DataTable MostrarHistorial()
        {
            SqlConnection con = Conexion.Conexion.Conectar();
            string comando = "SELECT    h.id_Historial as #,   p.nombre_Paciente AS nombre_paciente,    m.nombre_Medico AS nombre_medico,    h.descripcion,    h.fecha FROM Historiales h INNER JOIN Pacientes p ON h.id_Paciente = p.id_Paciente INNER JOIN Medicos m ON h.id_Medico = m.id_Medico ORDER BY h.fecha DESC; ";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public bool InsertarHistorial()
        {
            try
            {
                SqlConnection con = Conexion.Conexion.Conectar();

                string comando = "Insert into Historial (id_Paciente, id_Medico, descripcion, fecha) " +
                    " values (@id_Paciente, @id_Medico, @descripcion, @fecha);";

                SqlCommand cmd = new SqlCommand(comando, con);

                cmd.Parameters.AddWithValue("@id_Paciente", id_Paciente);
                cmd.Parameters.AddWithValue("@id_Medico", id_Medico);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@fecha", fecha);

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

        public bool eliminarHistorial(int id)
        {
            try
            {
                SqlConnection conectar = Conexion.Conexion.Conectar();
                string consultaDelete = "Delete from Historial where id_Historial=@id_Historial";
                SqlCommand delete = new SqlCommand(consultaDelete, conectar);
                delete.Parameters.AddWithValue("@id_Historial", id);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool actualizarHistorial()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaUpdate = "update cita set id_Paciente=@id_Paciente,id_Medico=@id_Medico,descripcion=@descripcion,fecha=@fecha  where  id_Historial=@id_Historial";
                SqlCommand update = new SqlCommand(consultaUpdate, conexion);

                update.Parameters.AddWithValue("@id_Paciente", id_Paciente);
                update.Parameters.AddWithValue("@id_Medico", id_Medico);
                update.Parameters.AddWithValue("@descripcion", descripcion);
                update.Parameters.AddWithValue("@fecha", fecha);
                update.Parameters.AddWithValue("@id_Historial", id_Historial);

                update.ExecuteNonQuery();
                MessageBox.Show("Historial actualizado exitosamente.", "Actualización Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica si la consulta de actualizar esta correcta " + ex, "Error");
                return false;
            }
        }

        public static DataTable BuscarHistorial(string busqueda)
        {
            SqlConnection con = Conexion.Conexion.Conectar();

            string comando = @"SELECT 
                               h.id_Historial as #,
                               p.nombre_Paciente AS nombre_paciente,
                               m.nombre_Medico AS nombre_medico,
                               h.descripcion,
                               h.fecha
                               FROM Historiales h
                               INNER JOIN Pacientes p ON h.id_Paciente = p.id_Paciente
                               INNER JOIN Medicos m ON h.id_Medico = m.id_Medico
                               WHERE p.nombre_Paciente LIKE '%' + @busqueda + '%' 
                               OR m.nombre_Medico LIKE '%' + @busqueda + '%';";

            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
