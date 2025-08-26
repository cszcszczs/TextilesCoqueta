using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class CN_Nomina
    {
        private readonly CD_Nomina objNomina = new CD_Nomina();
        private readonly CN_Empleado objEmpleado = new CN_Empleado();
        public bool RegistrarNomina(string codigo)
        {
            var empleados = objEmpleado.BuscarEmpleado(codigo);
            if (empleados.Count == 0)
                return false; // No se encontró el empleado
            var empleado = empleados[0];
            double salud = objEmpleado.DeduccionSalud(empleado);
            double pension = objEmpleado.DeduccionPension(empleado);
            double auxTransporte = objEmpleado.DeduccionAuxilioTransporte(empleado);
            double salarioNeto = objEmpleado.SalarioNeto(empleado);
            // F2 para formatear a decimales
            objNomina.RegistrarNomina(empleado, salud.ToString("F"), pension.ToString("F"), auxTransporte.ToString("F"), salarioNeto.ToString("F"));
            return true;
        }
        public List<string> ListarNomina()
        {
            return objNomina.ListarNomina();
        }
        public List<string> BuscarNomina(string codigo)
        {
            return objNomina.BuscarNomina(codigo);
        }
    }
}
