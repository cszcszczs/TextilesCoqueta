using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionEmpleados gestionEmpleados = new GestionEmpleados();
            gestionEmpleados.MdiParent = this;
            gestionEmpleados.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEmpleados listadoEmpleados = new ListadoEmpleados();
            listadoEmpleados.MdiParent = this;
            listadoEmpleados.Show();
        }

        private void salarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalarioEmpleado salarioEmpleado = new SalarioEmpleado();
            salarioEmpleado.MdiParent = this;
            salarioEmpleado.Show();
        }

        private void nominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina nomina = new Nomina();
            nomina.MdiParent = this;
            nomina.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
