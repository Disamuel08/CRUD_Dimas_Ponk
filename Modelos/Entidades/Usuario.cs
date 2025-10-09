using Modelos.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Modelos.Entidades
{
    public class Usuario
    {
        private int id_Usuario;
        private string nombre_Usuario;
        private string clave;
        private int id_Rol;

        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public string Nombre_Usuario { get => nombre_Usuario; set => nombre_Usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public int Id_Rol { get => id_Rol; set => id_Rol = value; }

        public bool RegistrarUsuario()
        {
            try
            {
                SqlConnection conn = Conexion.Conexion.Conectar();
                string query = "INSERT INTO Usuarios (nombre_Usuario, clave,  id_Rol) VALUES (@nombre_Usuario, @clave, @id_Rol);";

                SqlCommand insertar = new SqlCommand(query, conn);
                insertar.Parameters.AddWithValue("@nombre_Usuario", nombre_Usuario);
                insertar.Parameters.AddWithValue("@clave", clave);
                insertar.Parameters.AddWithValue("@id_Rol", id_Rol);

                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
                return false;
            }
        }

        public bool VerificarLogin(string nombreUsuario, string clave)
        {
            string hashEnBaseDeDatos = "";

            SqlConnection conn = Conexion.Conexion.Conectar();
            string query = "SELECT clave FROM Usuarios WHERE nombre_Usuario = @nombre_Usuario";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre_Usuario", nombreUsuario);

            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                return false;
            }
            else
            {
                hashEnBaseDeDatos = result.ToString();
                return BCrypt.Net.BCrypt.Verify(clave, hashEnBaseDeDatos);
            }
        }

        public int ObtenerRol(string nombreUsuario)
        {
            int id_Rol = 0;
            string servidor = "JARVIS\\SQLEXPRESS";
            string baseDeDatos = "ClinicaDB2";
            string conexion = $"Server={servidor};Database={baseDeDatos};Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_Rol FROM Usuario WHERE nombre_Usuario = @nombre", conn);
                cmd.Parameters.AddWithValue("@nombre_Usuario", nombreUsuario);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    id_Rol = Convert.ToInt32(result);
                }
            }

            return id_Rol;
        }

        public static DataTable cargarRoles()
        {
            SqlConnection conn = Conexion.Conexion.Conectar();
            string query = "SELECT id_Rol, nombre_Rol FROM Roles;";
            SqlDataAdapter dt = new SqlDataAdapter(query, conn);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            return tabla;
        }
    }



}
