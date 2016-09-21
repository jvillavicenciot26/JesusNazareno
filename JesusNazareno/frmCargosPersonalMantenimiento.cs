using JesusNazareno.Controller;
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
    public partial class frmCargosPersonalMantenimiento : Form
    {
        public frmCargosPersonalMantenimiento()
        {
            InitializeComponent();
        }

        private void frmCargosPersonalMantenimiento_Load(object sender, EventArgs e)
        {
            clsAccesoPersonal BD = new clsAccesoPersonal();
            dgvcargos.DataSource = BD.ConsultarTodoCargos();
        }
    }
}
