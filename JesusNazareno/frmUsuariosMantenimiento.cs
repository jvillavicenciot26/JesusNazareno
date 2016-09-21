using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JesusNazareno
{
    public partial class frmUsuariosMantenimiento : Form
    {
        public frmUsuariosMantenimiento()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmPersonalBusqueda frmperbus = new frmPersonalBusqueda();
            frmperbus.Show();
        }
    }
}
