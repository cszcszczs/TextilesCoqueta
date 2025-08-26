using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        private readonly CD_Empleado objEmpleado = new CD_Empleado();
        public void RegistrarEmpleado(string codigo, string nombre, string apellido, string edad, string cargo, string salario)
        {
            Empleado empleado = new Empleado
            {
                Codigo = codigo,
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Cargo = cargo,
                Salario = salario
            };
            objEmpleado.RegistrarEmpleado(empleado);
        }

        public List<Empleado> BuscarEmpleado(string codigo)
        {
            return objEmpleado.BuscarEmpleado(codigo);
        }
        public List<Empleado> ListarEmpleados()
        {
            return objEmpleado.ListarEmpleados();
        }

        public double DeduccionSalud(Empleado empleado)
        {
            if (double.TryParse(empleado.Salario, out double salario))
            {
                return salario * 0.04; // 4% de deducción para salud
            }
            return 0;
        }

        public double DeduccionPension(Empleado empleado)
        {
            if (double.TryParse(empleado.Salario, out double salario))
            {
                return salario * 0.04; // 4% de deducción para pension
            }
            return 0;
        }

        public double DeduccionAuxilioTransporte(Empleado empleado)
        {
            if (double.TryParse(empleado.Salario, out double salario))
            {
                if (salario <= 2847000) // Si el salario es menor o igual a 2,847,000
                {
                    return 200000; // Valor fijo del auxilio de transporte
                }
                return 0; // No hay auxilio de transporte si el salario es mayor a 2,847,000
            }
            return 0;
        }

        public double SalarioNeto(Empleado empleado)
        {
            if (double.TryParse(empleado.Salario, out double salario))
            {
                double deduccionSalud = DeduccionSalud(empleado);
                double deduccionPension = DeduccionPension(empleado);
                double deduccionAuxilioTransporte = DeduccionAuxilioTransporte(empleado);
                return salario - deduccionSalud - deduccionPension + deduccionAuxilioTransporte;
            }
            return 0;
        }
    }
}
