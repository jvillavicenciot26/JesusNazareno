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

        private void frmUsuariosMantenimiento_Load(object sender, EventArgs e)
        {
            clsAccesoUsuarios BD = new clsAccesoUsuarios();
            dtgvusuarios.DataSource = BD.ConsultarTodoUsuarios();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            clsUsuario Usu = new clsUsuario();
            clsAccesoUsuarios BD = new clsAccesoUsuarios();
            Usu.CodigoUsuario = int.Parse(txtcodigousuario.Text);
            Usu.CodigoPersonal = int.Parse(txtcodpersonal.Text);
            Usu.NombreUsuario = txtusuario.Text;
            Usu.ClaveUsuario = txtclaveusuario.Text;
            Usu.EstadoUsuario = cboestadousuario.SelectedItem.ToString();
            BD.RegistrarUsuario(Usu);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsUsuario Usu = new clsUsuario();
            clsAccesoUsuarios BD = new clsAccesoUsuarios();
            Usu.CodigoUsuario = int.Parse(txtcodigousuario.Text);
            Usu.CodigoPersonal = int.Parse(txtcodpersonal.Text);
            Usu.NombreUsuario = txtusuario.Text;
            Usu.ClaveUsuario = txtclaveusuario.Text;
            Usu.EstadoUsuario = cboestadousuario.SelectedItem.ToString();
            BD.ActualizarUsuario(Usu);
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            clsUsuario Usu = new clsUsuario();
            clsAccesoUsuarios BD = new clsAccesoUsuarios();
            Usu.CodigoUsuario = int.Parse(txtcodigousuario.Text);
            BD.EliminarUsuario(Usu);
        }

        private void dtgvusuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigousuario.Text = dtgvusuarios.CurrentRow.Cells[0].Value.ToString();
            txtcodpersonal.Text = dtgvusuarios.CurrentRow.Cells[1].Value.ToString();
            txtnompersonal.Text = dtgvusuarios.CurrentRow.Cells[2].Value.ToString();
            txtusuario.Text = dtgvusuarios.CurrentRow.Cells[3].Value.ToString();
            txtclaveusuario.Text = dtgvusuarios.CurrentRow.Cells[4].Value.ToString();
            cboestadousuario.SelectedItem = dtgvusuarios.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
