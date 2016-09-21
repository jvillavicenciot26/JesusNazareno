using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JesusNazareno.Controller;
using JesusNazareno.Model;

namespace JesusNazareno
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            clsLogin log = new clsLogin(txtusuario.Text, txtclave.Text);
            clsAccesoPersonal BD = new clsAccesoPersonal();
            String nomper = BD.ConsultarUsuario(log);
            if (nomper == "")
            {
                MessageBox.Show("Error en credenciales", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bienvenido " + nomper, "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPrincipal frmprinc = new frmPrincipal(nomper);
                frmprinc.Show();
                this.Hide();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
