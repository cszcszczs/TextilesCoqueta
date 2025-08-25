using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CapaDatos
{
    internal class CD_Empleado
    {
        private Empleado empleado = new Empleado();

        private string ruta = "C:\\Users\\USUARIO\\Documents\\empleados.txt";

        public void RegistrarEmpleado(Empleado empleado)
        {
            var carpeta = Path.GetDirectoryName(ruta);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            File.AppendAllText(ruta, empleado.LineaArchivo() + Environment.NewLine);
        }

        public List<Empleado> BuscarEmpleado(string codigo)
        {
            var lista = new List<Empleado>();
            if (!File.Exists(ruta))
            {
                return lista;
            }
            var lineas = File.ReadAllLines(ruta);
            foreach (var line in lineas)
            {
                var emp = empleado.separarLinea(line);
                if (emp.Codigo == codigo)
                    lista.Add(emp);
            }
            return lista;
        }

        public List<Empleado> ListarEmpleados()
        {
            var lista = new List<Empleado>();
            if (!File.Exists(ruta))
            {
                return lista;
            }
            var lineas = File.ReadAllLines(ruta);
            foreach (var line in lineas)
            {
                var emp = empleado.separarLinea(line);
                lista.Add(emp);
            }
            return lista;
        }
    }
}
