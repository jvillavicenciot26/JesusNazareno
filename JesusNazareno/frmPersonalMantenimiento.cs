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
    public partial class frmPersonalMantenimiento : Form
    {
        public frmPersonalMantenimiento()
        {
            InitializeComponent();
        }

        private void btnbuscarpersonal_Click(object sender, EventArgs e)
        {
            frmPersonalBusqueda frmPerBus = new frmPersonalBusqueda();
            frmPerBus.Show();
        }

        private void frmPersonalMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void btnrGuardar_Click(object sender, EventArgs e)
        {
            clsPersonal Per = new clsPersonal();
            clsAccesoPersonal BD = new clsAccesoPersonal();
            Per.CodigoPersonal = int.Parse(txtcodpersonal.Text);
            Per.NombrePersonal = txtnombres.Text;
            Per.ApePatPersonal = txtapepaterno.Text;
            Per.ApeMatPersonal = txtapematerno.Text;
            Per.EMailPersonal = txtmail.Text;
            Per.FonoPersonal = txtTelefono.Text;
            Per.EstadoPersonal = cboEstado.SelectedItem.ToString();
            Per.IdCargoPersonal = (cbocargopersonal.SelectedIndex + 1);
            BD.RegistrarPersonal(Per);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            clsAccesoPersonal BD = new clsAccesoPersonal();
            cbocargopersonal.DataSource = BD.LlenarComboCargos();
            cbocargopersonal.ValueMember = "NombreCargo";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsPersonal Per = new clsPersonal();
            clsAccesoPersonal BD = new clsAccesoPersonal();
            Per.CodigoPersonal = int.Parse(txtcodpersonal.Text);
            Per.NombrePersonal = txtnombres.Text;
            Per.ApePatPersonal = txtapepaterno.Text;
            Per.ApeMatPersonal = txtapematerno.Text;
            Per.EMailPersonal = txtmail.Text;
            Per.FonoPersonal = txtTelefono.Text;
            Per.EstadoPersonal = cboEstado.SelectedItem.ToString();
            Per.IdCargoPersonal = (cbocargopersonal.SelectedIndex + 1);
            BD.ActualizarPersonal(Per);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            clsPersonal Per = new clsPersonal();
            clsAccesoPersonal BD = new clsAccesoPersonal();
            Per.CodigoPersonal = int.Parse(txtcodpersonal.Text);
            BD.EliminarPersonal(Per);
        }
    }
}
