using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Paciente
    {
        private int id_Paciente;
        private string nombre_Paciente;
        private string direccion;
        private string telefono;
        private DateTime fecha_Nacimiento;
        private bool genero;
        private string correo_Electronico;

        public int Id_Paciente { get => id_Paciente; set => id_Paciente = value; }
        public string Nombre_Paciente { get => nombre_Paciente; set => nombre_Paciente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime Fecha_Nacimiento { get => fecha_Nacimiento; set => fecha_Nacimiento = value; }
        public bool Genero { get => genero; set => genero = value; }
        public string Correo_Electronico { get => correo_Electronico; set => correo_Electronico = value; }


    }
}
