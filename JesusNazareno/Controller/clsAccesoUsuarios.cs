using JesusNazareno.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JesusNazareno.Controller
{
    class clsAccesoUsuarios
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
        //MySqlConnection con = new MySqlConnection("server=191.234.183.224; Uid=root; Password=bitnami; Database=iejesusnazareno; Port=3306");

        public DataTable ConsultarTodoUsuarios()
        {
            con.Open();
            MySqlDataAdapter mdaUsuarios = new MySqlDataAdapter();
            DataTable dtUsuarios = new DataTable();
            try
            {
                mdaUsuarios.SelectCommand = new MySqlCommand("consultartodousuarios", con);
                mdaUsuarios.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaUsuarios.Fill(dtUsuarios);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtUsuarios;
        }

        public void RegistrarUsuario(clsUsuario Usu)
        {
            con.Open();
            MySqlCommand mcRegPersonal;
            try
            {
                if (Usu != null)
                {
                    mcRegPersonal = new MySqlCommand("registrarusuario", con);
                    mcRegPersonal.CommandType = CommandType.StoredProcedure;
                    mcRegPersonal.Parameters.AddWithValue("@codigousuario", Usu.CodigoUsuario);
                    mcRegPersonal.Parameters.AddWithValue("@codigopersonal", Usu.CodigoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@nombre", Usu.NombreUsuario);
                    mcRegPersonal.Parameters.AddWithValue("@clave", Usu.ClaveUsuario);
                    mcRegPersonal.Parameters.AddWithValue("@estado", Usu.EstadoUsuario);
                    mcRegPersonal.ExecuteNonQuery();
                    MessageBox.Show("EL USUARIO " + Usu.NombreUsuario + " SE REGISTRO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR EN EL REGISTRO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void ActualizarUsuario(clsUsuario Usu)
        {
            con.Open();
            MySqlCommand mcRegPersonal;
            try
            {
                if (Usu != null)
                {
                    mcRegPersonal = new MySqlCommand("actualizarusuario", con);
                    mcRegPersonal.CommandType = CommandType.StoredProcedure;
                    mcRegPersonal.Parameters.AddWithValue("@codigousuario", Usu.CodigoUsuario);
                    mcRegPersonal.Parameters.AddWithValue("@codigopersonal", Usu.CodigoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@nombre", Usu.NombreUsuario);
                    mcRegPersonal.Parameters.AddWithValue("@clave", Usu.ClaveUsuario);
                    mcRegPersonal.Parameters.AddWithValue("@estado", Usu.EstadoUsuario);
                    mcRegPersonal.ExecuteNonQuery();
                    MessageBox.Show("LOS DATOS DEL USUARIO " + Usu.NombreUsuario + " SE ACTUALIZARON EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR EN LA ACTUALIZACION", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void EliminarUsuario(clsUsuario Usu)
        {
            con.Open();
            MySqlCommand mcRegPersonal;
            try
            {
                if (Usu != null)
                {
                    mcRegPersonal = new MySqlCommand("eliminarusuario", con);
                    mcRegPersonal.CommandType = CommandType.StoredProcedure;
                    mcRegPersonal.Parameters.AddWithValue("@codigousuario", Usu.CodigoUsuario);
                    mcRegPersonal.ExecuteNonQuery();
                    MessageBox.Show("LOS DATOS DEL USUARIO HAN SIDO ELIMINADOS EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR EN LA ELIMINACIÓN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}