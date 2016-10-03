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
    class clsAccesoActividades
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
        //MySqlConnection con = new MySqlConnection("server=191.234.183.224; Uid=root; Password=bitnami; Database=iejesusnazareno; Port=3306");
        public DataTable ConsultarTodoActividades()
        {
            con.Open();
            MySqlDataAdapter mdaActividades = new MySqlDataAdapter();
            DataTable dtActividades = new DataTable();
            try
            {
                mdaActividades.SelectCommand = new MySqlCommand("consultatodoactividades", con);
                mdaActividades.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaActividades.Fill(dtActividades);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtActividades;
        }

        public void RegistrarActividad(clsActividad Act)
        {
            con.Open();
            MySqlCommand mcRegActividad;
            try
            {
                if (Act != null)
                {
                    mcRegActividad = new MySqlCommand("registraractividad", con);
                    mcRegActividad.CommandType = CommandType.StoredProcedure;
                    mcRegActividad.Parameters.AddWithValue("@codigo", Act.CodigoActividad);
                    mcRegActividad.Parameters.AddWithValue("@nombre", Act.NombreActividad);
                    mcRegActividad.Parameters.AddWithValue("@detalle", Act.DetalleActividad);
                    mcRegActividad.ExecuteNonQuery();
                    MessageBox.Show("LA ACTIVIDAD" + Act.NombreActividad + " SE REGISTRO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ActualizarActividad(clsActividad Act)
        {
            con.Open();
            MySqlCommand mcRegActividad;
            try
            {
                if (Act != null)
                {
                    mcRegActividad = new MySqlCommand("actualizaractividad", con);
                    mcRegActividad.CommandType = CommandType.StoredProcedure;
                    mcRegActividad.Parameters.AddWithValue("@codigo", Act.CodigoActividad);
                    mcRegActividad.Parameters.AddWithValue("@nombre", Act.NombreActividad);
                    mcRegActividad.Parameters.AddWithValue("@detalle", Act.DetalleActividad);
                    mcRegActividad.ExecuteNonQuery();
                    MessageBox.Show("LA ACTIVIDAD" + Act.NombreActividad + " SE ACTUALIZO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void EliminarActividad(clsActividad Act)
        {
            con.Open();
            MySqlCommand mcEliActividad;
            try
            {
                if (Act != null)
                {
                    mcEliActividad = new MySqlCommand("eliminaractividad", con);
                    mcEliActividad.CommandType = CommandType.StoredProcedure;
                    mcEliActividad.Parameters.AddWithValue("@codigo", Act.CodigoActividad);
                    mcEliActividad.ExecuteNonQuery();
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