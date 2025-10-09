using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos
{
    public class Cita
    {
        private int id_Cita;
        private DateTime fecha_Hora;
        private int id_Paciente;
        private int id_Medico;
        private string motivo;
        private string estado;

        public int Id_Cita { get => id_Cita; set => id_Cita = value; }
        public DateTime Fecha_Hora { get => fecha_Hora; set => fecha_Hora = value; }
        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public int Id_Medico { get => id_Medico; set => id_Medico = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Estado { get => estado; set => estado = value; }

        public static DataTable MostrarCitas()
        {
            SqlConnection con = Conexion.Conexion.Conectar();
            string comando = "SELECT * FROM cita;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public bool InsertarCita()
        {
            try
            {
                SqlConnection con = Conexion.Conexion.Conectar();

                string comando = "Insert into cita (id_Paciente, id_Medico, motivo, estado, fecha_Hora) " +
                    " values (@id_Paciente, @id_Medico, @motivo, @estado, @fecha_Hora);";

                SqlCommand cmd = new SqlCommand(comando, con);

                cmd.Parameters.AddWithValue("@id_Paciente", id_Paciente);
                cmd.Parameters.AddWithValue("@id_Medico", id_Medico);
                cmd.Parameters.AddWithValue("@motivo", motivo);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@fecha_Hora", fecha_Hora);

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

        public bool eliminarCita(int id)
        {
            try
            {
                SqlConnection conectar = Conexion.Conexion.Conectar();
                string consultaDelete = "Delete from cita where id_Cita=@id_Cita";
                SqlCommand delete = new SqlCommand(consultaDelete, conectar);
                delete.Parameters.AddWithValue("@id_Cita", id);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool actualizarCita()
        {
            try
            {
                SqlConnection conexion = Conexion.Conexion.Conectar();
                string consultaUpdate = "update cita set id_Paciente=@id_Paciente,id_Medico=@id_Medico,motivo=@motivo,estado=@estado, fecha_Hora=@fecha_Hora  where  id_Cita=@ id_Cita";
                SqlCommand update = new SqlCommand(consultaUpdate, conexion);

                update.Parameters.AddWithValue("@id_Paciente", id_Paciente);
                update.Parameters.AddWithValue("@id_Medico", id_Medico);
                update.Parameters.AddWithValue("@motivo", motivo);
                update.Parameters.AddWithValue("@estado", estado);
                update.Parameters.AddWithValue("@fecha_Hora", fecha_Hora);
                update.Parameters.AddWithValue("@id_Cita", id_Cita);

                update.ExecuteNonQuery();
                MessageBox.Show("Cita actualizada exitosamente.", "Actualización Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica si la consulta de actualizar esta correcta " + ex, "Error");
                return false;
            }
        }

        public static DataTable BuscarCita(string busqueda)
        {
            SqlConnection con = Conexion.Conexion.Conectar();

            string comando = @"
               SELECT c.id_Cita, c.fecha_Hora, 
               p.Nombre AS Paciente, 
               m.Nombre AS Medico, 
               c.motivo, c.estado
               FROM Cita c
               INNER JOIN Paciente p ON c.id_Paciente = p.id_Paciente
               INNER JOIN Medico m ON c.id_Medico = m.id_Medico
               WHERE p.Nombre LIKE @busqueda OR m.Nombre LIKE @busqueda";

            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
