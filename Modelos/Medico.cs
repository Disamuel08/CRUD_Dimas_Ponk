using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
