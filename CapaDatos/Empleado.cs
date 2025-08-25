using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Empleado
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Cargo { get; set; }
        public string Salario { get; set; }

        public Empleado() { }
        public Empleado(string codigo, string nombre, string apellido, string edad, string cargo, string salario)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Cargo = cargo;
            Salario = salario;
        }

        public string LineaArchivo()
        {
            return $"{Codigo},{Nombre},{Apellido},{Edad},{Cargo},{Salario}";
        }

        public Empleado separarLinea(string linea)
        {
            var datos = linea.Split(',');
            return new Empleado
            {
                Codigo = datos[0],
                Nombre = datos[1],
                Apellido = datos[2],
                Edad = datos[3],
                Cargo = datos[4],
                Salario = datos[5]
            };
        }

    }
}
