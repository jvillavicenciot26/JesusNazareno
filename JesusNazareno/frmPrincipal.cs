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
    public partial class frmPrincipal : Form
    {
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            tsslFechaHora.Text = DateTime.Now.ToString();
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(String nomper)
        {
            InitializeComponent();
            tsstnomper.Text = nomper;
            tsslFechaHora.Text = DateTime.Now.ToString();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPersonalMantenimiento frmPerMan = new frmPersonalMantenimiento();
            frmPerMan.Show();
        }

        private void registroToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmUsuariosMantenimiento frmUsuMan = new frmUsuariosMantenimiento();
            frmUsuMan.Show();
        }

        internal void Load(string nomper)
        {
            throw new NotImplementedException();
        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRecursosMantenimiento frmRecMan = new frmRecursosMantenimiento();
            frmRecMan.Show();
        }

        private void registroToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmActividadesMantenimiento frmActMan = new frmActividadesMantenimiento();
            frmActMan.Show();
        }

        private void mantenimientoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmTipodeRecursoMantenimiento frmTipoRec = new frmTipodeRecursoMantenimiento();
            frmTipoRec.Show();
        }

        private void mantenimientoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmCargosPersonalMantenimiento frmCarPer = new frmCargosPersonalMantenimiento();
            frmCarPer.Show();
        }
    }
}
