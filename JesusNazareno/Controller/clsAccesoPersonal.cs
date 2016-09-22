using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using JesusNazareno.Model;
using System.Windows.Forms;

namespace JesusNazareno.Controller
{
    public class clsAccesoPersonal
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
        //MySqlConnection con = new MySqlConnection("server=191.234.183.224; Uid=root; Password=bitnami; Database=iejesusnazareno; Port=3306");

        public String ConsultarUsuario(clsLogin log)
        {
            con.Open();
            MySqlCommand cmd;
            MySqlDataReader consulta;
            String resultado = null;
            try
            {
                cmd = new MySqlCommand("consultausuario",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nomusu", log.Usuario);
                cmd.Parameters.AddWithValue("claveusu", log.Clave);
                consulta = cmd.ExecuteReader();
                while (consulta.Read())
                {
                    resultado = consulta.GetString(0);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return resultado;
        }

        public DataTable ConsultarTodoPersonal()
        {
            con.Open();
            MySqlDataAdapter mdaPersonal = new MySqlDataAdapter();
            DataTable dtPersonal = new DataTable();
            try
            {
                mdaPersonal.SelectCommand = new MySqlCommand("consultatodopersonal", con);
                mdaPersonal.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaPersonal.Fill(dtPersonal);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtPersonal;
        }

        public DataTable FiltrarPersonal(string buscarpor, string parametro)
        {
            con.Open();
            MySqlCommand mcFilPersonal;
            MySqlDataAdapter mdaFilPersonal = new MySqlDataAdapter();
            DataTable dtFilPersonal = new DataTable();
            try
            {
                mcFilPersonal = new MySqlCommand("filtrarpersonal", con);
                mcFilPersonal.CommandType = CommandType.StoredProcedure;
                mcFilPersonal.Parameters.AddWithValue("@buscarpor", buscarpor);
                mcFilPersonal.Parameters.AddWithValue("@param", parametro);
                mdaFilPersonal.SelectCommand = mcFilPersonal;
                mdaFilPersonal.Fill(dtFilPersonal);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtFilPersonal;
        }

        public void RegistrarPersonal(clsPersonal Per)
        {
            con.Open();
            MySqlCommand mcRegPersonal;
            try
            {
                if (Per != null)
                {
                    mcRegPersonal = new MySqlCommand("registrarpersonal", con);
                    mcRegPersonal.CommandType = CommandType.StoredProcedure;
                    mcRegPersonal.Parameters.AddWithValue("@codigo", Per.CodigoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@nombre", Per.NombrePersonal);
                    mcRegPersonal.Parameters.AddWithValue("@paterno", Per.ApePatPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@materno", Per.ApeMatPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@mail", Per.EMailPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@fono", Per.FonoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@estado", Per.EstadoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@cargo", Per.IdCargoPersonal);
                    mcRegPersonal.ExecuteNonQuery();
                    MessageBox.Show("EL PERSONAL " + Per.NombrePersonal + " " + Per.ApePatPersonal + " " + Per.ApeMatPersonal + " SE REGISTRO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ActualizarPersonal(clsPersonal Per)
        {
            con.Open();
            MySqlCommand mcRegPersonal;
            try
            {
                if (Per != null)
                {
                    mcRegPersonal = new MySqlCommand("actualizarpersonal", con);
                    mcRegPersonal.CommandType = CommandType.StoredProcedure;
                    mcRegPersonal.Parameters.AddWithValue("@codigo", Per.CodigoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@nombre", Per.NombrePersonal);
                    mcRegPersonal.Parameters.AddWithValue("@paterno", Per.ApePatPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@materno", Per.ApeMatPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@mail", Per.EMailPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@fono", Per.FonoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@estado", Per.EstadoPersonal);
                    mcRegPersonal.Parameters.AddWithValue("@cargo", Per.IdCargoPersonal);
                    mcRegPersonal.ExecuteNonQuery();
                    MessageBox.Show("LOS DATOS DE " + Per.NombrePersonal + " " + Per.ApePatPersonal + " " + Per.ApeMatPersonal + " SE ACTUALIZARON EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR AL ACTUALIZAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void EliminarPersonal(clsPersonal Per)
        {
            con.Open();
            MySqlCommand mcRegPersonal;
            try
            {
                if (Per != null)
                {
                    mcRegPersonal = new MySqlCommand("eliminarpersonal", con);
                    mcRegPersonal.CommandType = CommandType.StoredProcedure;
                    mcRegPersonal.Parameters.AddWithValue("@codigo", Per.CodigoPersonal);
                    mcRegPersonal.ExecuteNonQuery();
                    MessageBox.Show("LOS DATOS SE ELIMINARON EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR AL ELIMINAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public DataTable LlenarComboCargos()
        {
            con.Open();
            MySqlDataAdapter mdaComboCargos = new MySqlDataAdapter();
            DataTable dtComboCargos = new DataTable();
            try
            {
                mdaComboCargos.SelectCommand = new MySqlCommand("llenarcombocargopersonal", con);
                mdaComboCargos.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaComboCargos.Fill(dtComboCargos);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtComboCargos;
        }
    }
}