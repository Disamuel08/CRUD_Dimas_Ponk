using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
