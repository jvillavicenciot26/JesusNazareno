using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JesusNazareno.Controller;
using JesusNazareno.Model;

namespace JesusNazareno
{
    public partial class frmPersonalBusqueda : Form
    {
        public frmPersonalBusqueda()
        {
            InitializeComponent();
        }

        private void frmPersonalBusqueda_Load(object sender, EventArgs e)
        {
            clsAccesoPersonal BD = new clsAccesoPersonal();
            dgvpersonal.DataSource = BD.ConsultarTodoPersonal();
        }

        private void txtparametro_TextChanged(object sender, EventArgs e)
        {
            String parametro = txtparametro.Text;
            String buscar = cbobuscar.SelectedItem.ToString();
            switch (buscar)
            {
                case "AP. PATERNO":
                    buscar = "paterno";
                    break;
                case "AP. MATERNO":
                    buscar = "materno";
                    break;
                case "NOMBRE":
                    buscar = "nombre";
                    break;
            }
            clsAccesoPersonal BD = new clsAccesoPersonal();
            dgvpersonal.DataSource = BD.FiltrarPersonal(buscar,parametro);
        }
    }
}
