using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CapaDatos
{
    public class CD_Empleado
    {
        private readonly string ruta;

        // constructor para inicializar la ruta del archivo dinamicamente
        public CD_Empleado()
        {
            ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "empleados.txt");
        }

        private Empleado empleado = new Empleado();

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
