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
    public partial class frmRecursosMantenimiento : Form
    {
        public frmRecursosMantenimiento()
        {
            InitializeComponent();
        }

        private void btnbuscarrecurso_Click(object sender, EventArgs e)
        {
            frmRecursoBusqueda frmRecBus = new frmRecursoBusqueda();
            frmRecBus.Show();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            clsRecurso Rec = new clsRecurso();
            clsAccesoRecursos BD = new clsAccesoRecursos();
            Rec.CodigoRecurso = int.Parse(txtcodigorecurso.Text);
            Rec.NombreRecurso = txtnombrerecurso.Text;
            Rec.SerieRecurso = txtserierecurso.Text;
            Rec.EstadoRecurso = cboestadorecurso.SelectedItem.ToString();
            Rec.MarcaRecurso = txtmarca.Text;
            Rec.CodigoTipRecurso = (cbotiporecurso.SelectedIndex + 1);
            BD.RegistrarRecursos(Rec);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //clsAccesoRecursos BD = new clsAccesoRecursos();
            //cbotiporecurso.DataSource = BD.LlenarComboTipoRecursos();
            //cbotiporecurso.ValueMember = "NombreTipoRecurso";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsRecurso Rec = new clsRecurso();
            clsAccesoRecursos BD = new clsAccesoRecursos();
            Rec.CodigoRecurso = int.Parse(txtcodigorecurso.Text);
            Rec.NombreRecurso = txtnombrerecurso.Text;
            Rec.SerieRecurso = txtserierecurso.Text;
            Rec.EstadoRecurso = cboestadorecurso.SelectedItem.ToString();
            Rec.MarcaRecurso = txtmarca.Text;
            Rec.CodigoTipRecurso = (cbotiporecurso.SelectedIndex + 1);
            BD.ActualizarRecursos(Rec);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsRecurso Rec = new clsRecurso();
            clsAccesoRecursos BD = new clsAccesoRecursos();
            Rec.CodigoRecurso = int.Parse(txtcodigorecurso.Text);
            BD.EliminarRecurso(Rec);
        }

        private void frmRecursosMantenimiento_Load(object sender, EventArgs e)
        {
            clsAccesoRecursos BD = new clsAccesoRecursos();
            cbotiporecurso.DataSource = BD.LlenarComboTipoRecursos();
            cbotiporecurso.ValueMember = "NombreTipoRecurso";
        }

        public void codigobusqueda (int codigo)
        {
            txtcodigorecurso.Text = codigo.ToString();
            clsAccesoRecursos BD = new clsAccesoRecursos();
            clsRecurso Rec = new clsRecurso();
            Rec = BD.BuscarRecurso(codigo);
            txtnombrerecurso.Text = Rec.NombreRecurso;
            txtmarca.Text = Rec.MarcaRecurso;
            txtserierecurso.Text = Rec.SerieRecurso;
            cboestadorecurso.SelectedItem = Rec.EstadoRecurso;
            cbotiporecurso.SelectedIndex = (Rec.CodigoTipRecurso - 1);
        }
    }
}
