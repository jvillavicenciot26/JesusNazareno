using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JesusNazareno.Controller;
using System.Windows.Forms;

namespace JesusNazareno
{
    public partial class frmRecursoBusqueda : Form
    {
        public frmRecursoBusqueda()
        {
            InitializeComponent();
        }

        private void frmRecursoBusqueda_Load(object sender, EventArgs e)
        {
            clsAccesoRecursos BD = new clsAccesoRecursos();
            dgvrecurso.DataSource = BD.ConsultarTodoRecursos();
        }

        private void txtparametro_TextChanged(object sender, EventArgs e)
        {
            String parametro = txtparametro.Text;
            String buscar = cbobuscar.SelectedItem.ToString();
            switch (buscar)
            {
                case "NOMBRE":
                    buscar = "nombre";
                    break;
                case "MARCA":
                    buscar = "marca";
                    break;
                case "SERIE":
                    buscar = "serie";
                    break;
                case "TIPO":
                    buscar = "tipo";
                    break;
            }
            clsAccesoRecursos BD = new clsAccesoRecursos();
            dgvrecurso.DataSource = BD.FiltrarRecursos(buscar, parametro);
        }

        private void dgvrecurso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = int.Parse(dgvrecurso.CurrentRow.Cells[0].Value.ToString());
            frmRecursosMantenimiento frmRecMan = Application.OpenForms.OfType<frmRecursosMantenimiento>().FirstOrDefault();
            if (frmRecMan != null)
            {
                frmRecMan.codigobusqueda(codigo);
            }
            this.Close();
        }
    }
}
