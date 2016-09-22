using JesusNazareno.Controller;
using JesusNazareno.Model;
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
            clsAccesoTipoRecursos BD = new clsAccesoTipoRecursos();
            dtgtiporecurso.DataSource = BD.ConsultarTodoTipoRecursos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsTipoRecurso TipRec = new clsTipoRecurso();
            clsAccesoTipoRecursos BD = new clsAccesoTipoRecursos();
            TipRec.CodigoTipoRecurso = int.Parse(txtcodigotipo.Text);
            TipRec.NombreTipoRecurso = txtnombretipo.Text;
            TipRec.EstadoTipoRecurso = cboestadotiporecurso.SelectedItem.ToString();
            BD.RegistrarTipoRecurso(TipRec);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsTipoRecurso TipRec = new clsTipoRecurso();
            clsAccesoTipoRecursos BD = new clsAccesoTipoRecursos();
            TipRec.CodigoTipoRecurso = int.Parse(txtcodigotipo.Text);
            TipRec.NombreTipoRecurso = txtnombretipo.Text;
            TipRec.EstadoTipoRecurso = cboestadotiporecurso.SelectedItem.ToString();
            BD.ActualizarTipoRecurso(TipRec);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsTipoRecurso TipRec = new clsTipoRecurso();
            clsAccesoTipoRecursos BD = new clsAccesoTipoRecursos();
            TipRec.CodigoTipoRecurso = int.Parse(txtcodigotipo.Text);
            BD.EliminarTipoRecurso(TipRec);
        }
    }
}
