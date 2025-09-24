using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos.Conexion
{
    public class Conexion
    {
        private static string servidor = "";
        private static string baseDeDatos = "";

        public static SqlConnection Conectar()
        {
            try
            {
                string cadena = $"Data Source={servidor};Initial Catalog={baseDeDatos};Integrated Security=true;";
                SqlConnection conexion = new SqlConnection(cadena);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar al servidor" + ex, "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
