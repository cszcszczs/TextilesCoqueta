using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CapaDatos
{
    public class CD_Nomina
    {
        private readonly string ruta;
        // constructor para inicializar la ruta del archivo dinamicamente
        public CD_Nomina()
        {
            ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "nomina.txt");
        }

        public void RegistrarNomina(Empleado empleado, string deduccionSalud, string deduccionPension, string deduccionAuxilioTransporte, string salarioNeto)
        {
            var carpeta = Path.GetDirectoryName(ruta);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            var linea = $"{empleado.Codigo},{empleado.Apellido},{empleado.Salario},{deduccionSalud},{deduccionPension},{deduccionAuxilioTransporte},{salarioNeto}";
            File.AppendAllText(ruta, linea + Environment.NewLine);
        }

        public List<string> ListarNomina()
        {
            var lista = new List<string>();
            if (!File.Exists(ruta))
            {
                return lista;
            }
            var lineas = File.ReadAllLines(ruta);
            foreach (var line in lineas)
            {
                lista.Add(line);
            }
            return lista;
        }

        public List<string> BuscarNomina(string codigo)
        {
            var lista = new List<string>();
            if (!File.Exists(ruta))
            {
                return lista;
            }
            var lineas = File.ReadAllLines(ruta);
            foreach (var line in lineas)
            {
                var datos = line.Split(',');
                if (datos[0] == codigo)
                    lista.Add(line);
            }
            return lista;
        }
    }
}
