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
    class clsAccesoCargos
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
        //MySqlConnection con = new MySqlConnection("server=191.234.183.224; Uid=root; Password=bitnami; Database=iejesusnazareno; Port=3306");

        public DataTable ConsultarTodoCargos()
        {
            con.Open();
            MySqlDataAdapter mdaCargos = new MySqlDataAdapter();
            DataTable dtCargos = new DataTable();
            try
            {
                mdaCargos.SelectCommand = new MySqlCommand("consultatodocargos", con);
                mdaCargos.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaCargos.Fill(dtCargos);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtCargos;
        }
        public void RegistrarCargo(clsCargo Car)
        {
            con.Open();
            MySqlCommand mcRegCargo;
            try
            {
                if (Car != null)
                {
                    mcRegCargo = new MySqlCommand("registrarcargo", con);
                    mcRegCargo.CommandType = CommandType.StoredProcedure;
                    mcRegCargo.Parameters.AddWithValue("@codigo", Car.CodigoCargo);
                    mcRegCargo.Parameters.AddWithValue("@nombre", Car.NombreCargo);
                    mcRegCargo.ExecuteNonQuery();
                    MessageBox.Show("EL CARGO" + Car.NombreCargo + " SE REGISTRO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void ActualizarCargo(clsCargo Car)
        {
            con.Open();
            MySqlCommand mcActCargo;
            try
            {
                if (Car != null)
                {
                    mcActCargo = new MySqlCommand("actualizarcargo", con);
                    mcActCargo.CommandType = CommandType.StoredProcedure;
                    mcActCargo.Parameters.AddWithValue("@codigo", Car.CodigoCargo);
                    mcActCargo.Parameters.AddWithValue("@nombre", Car.NombreCargo);
                    mcActCargo.ExecuteNonQuery();
                    MessageBox.Show("EL CARGO" + Car.NombreCargo + " SE ACTUALIZO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void EliminarCargo(clsCargo Car)
        {
            con.Open();
            MySqlCommand mcEliCargo;
            try
            {
                if (Car != null)
                {
                    mcEliCargo = new MySqlCommand("eliminarcargo", con);
                    mcEliCargo.CommandType = CommandType.StoredProcedure;
                    mcEliCargo.Parameters.AddWithValue("@codigo", Car.CodigoCargo);
                    mcEliCargo.ExecuteNonQuery();
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
    }
}
