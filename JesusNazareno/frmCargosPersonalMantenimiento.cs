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
    public partial class frmCargosPersonalMantenimiento : Form
    {
        public frmCargosPersonalMantenimiento()
        {
            InitializeComponent();
        }

        private void frmCargosPersonalMantenimiento_Load(object sender, EventArgs e)
        {
            clsAccesoCargos BD = new clsAccesoCargos();
            dgvcargos.DataSource = BD.ConsultarTodoCargos();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            clsAccesoCargos BD = new clsAccesoCargos();
            clsCargo Car = new clsCargo();
            Car.CodigoCargo = int.Parse(txtcodigocargo.Text.ToString());
            Car.NombreCargo = txtnombrecargo.Text;
            BD.RegistrarCargo(Car);
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            clsAccesoCargos BD = new clsAccesoCargos();
            clsCargo Car = new clsCargo();
            Car.CodigoCargo = int.Parse(txtcodigocargo.Text.ToString());
            Car.NombreCargo = txtnombrecargo.Text;
            BD.ActualizarCargo(Car);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            clsAccesoCargos BD = new clsAccesoCargos();
            clsCargo Car = new clsCargo();
            Car.CodigoCargo = int.Parse(txtcodigocargo.Text.ToString());
            BD.EliminarCargo(Car);
        }

        private void dgvcargos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigocargo.Text = dgvcargos.CurrentRow.Cells[0].Value.ToString();
            txtnombrecargo.Text = dgvcargos.CurrentRow.Cells[1].Value.ToString();
            cboestadocargo.SelectedItem = dgvcargos.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
