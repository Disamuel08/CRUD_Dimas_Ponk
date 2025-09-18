using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
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


    }
}
