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
    public partial class frmActividadesMantenimiento : Form
    {
        public frmActividadesMantenimiento()
        {
            InitializeComponent();
        }

        private void frmActividadesMantenimiento_Load(object sender, EventArgs e)
        {
            clsAccesoActividades BD = new clsAccesoActividades();
            dgvActividades.DataSource = BD.ConsultarTodoActividades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsActividad Act = new clsActividad();
            clsAccesoActividades BD = new clsAccesoActividades();
            Act.CodigoActividad = int.Parse(txtcodigoactividad.Text);
            Act.NombreActividad = txtnombreactividad.Text;
            Act.DetalleActividad = rtbdetalle.Text;
            BD.RegistrarActividad(Act);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsActividad Act = new clsActividad();
            clsAccesoActividades BD = new clsAccesoActividades();
            Act.CodigoActividad = int.Parse(txtcodigoactividad.Text);
            Act.NombreActividad = txtnombreactividad.Text;
            Act.DetalleActividad = rtbdetalle.Text;
            BD.ActualizarActividad(Act);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsActividad Act = new clsActividad();
            clsAccesoActividades BD = new clsAccesoActividades();
            Act.CodigoActividad = int.Parse(txtcodigoactividad.Text);
            BD.EliminarActividad(Act);
        }
    }
}
