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
    public partial class frmTipodeRecursoMantenimiento : Form
    {
        public frmTipodeRecursoMantenimiento()
        {
            InitializeComponent();
        }

        private void frmTipodeRecursoMantenimiento_Load(object sender, EventArgs e)
        {
            clsAccesoRecursos BD = new clsAccesoRecursos();
            dtgtiporecurso.DataSource = BD.ConsultarTodoTipoRecursos();
        }
    }
}
