using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistas.Controles
{
    internal class ControlDeAcceso
    {
        public static bool TienePermiso(int idRol, string nombreFormulario)
        {
            var permisos = new Dictionary<int, List<string>>
    {
        { 1, new List<string> { "frmCItas", "frmHistorial", "frmMedicos", "frmPacientes"  } }, // Admin
        { 2, new List<string> { "frmPacientes", "frmHistorial", "frmCItas"} }, // Medico
        { 3, new List<string> { "frmCItas"} } // Recepcionista
    };

            return permisos.ContainsKey(idRol) && permisos[idRol].Contains(nombreFormulario);
        }
    }
}

