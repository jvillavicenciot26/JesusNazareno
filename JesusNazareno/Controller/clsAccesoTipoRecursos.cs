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
    class clsAccesoTipoRecursos
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
        //MySqlConnection con = new MySqlConnection("server=191.234.183.224; Uid=root; Password=bitnami; Database=iejesusnazareno; Port=3306");
        public DataTable ConsultarTodoTipoRecursos()
        {
            con.Open();
            MySqlDataAdapter mdaTipoRecursos = new MySqlDataAdapter();
            DataTable dtTipoRecursos = new DataTable();
            try
            {
                mdaTipoRecursos.SelectCommand = new MySqlCommand("consultatodotiporecursos", con);
                mdaTipoRecursos.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaTipoRecursos.Fill(dtTipoRecursos);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtTipoRecursos;
        }

        public void RegistrarTipoRecurso(clsTipoRecurso TipRec)
        {
            con.Open();
            MySqlCommand mcRegTipoRecurso;
            try
            {
                if (TipRec != null)
                {
                    mcRegTipoRecurso = new MySqlCommand("registrartiporecurso", con);
                    mcRegTipoRecurso.CommandType = CommandType.StoredProcedure;
                    mcRegTipoRecurso.Parameters.AddWithValue("@codigo", TipRec.CodigoTipoRecurso);
                    mcRegTipoRecurso.Parameters.AddWithValue("@nombre", TipRec.NombreTipoRecurso);
                    mcRegTipoRecurso.Parameters.AddWithValue("@estado", TipRec.EstadoTipoRecurso);
                    mcRegTipoRecurso.ExecuteNonQuery();
                    MessageBox.Show("EL TIPO DE RECURSO" + TipRec.NombreTipoRecurso + " SE REGISTRO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void ActualizarTipoRecurso(clsTipoRecurso TipRec)
        {
            con.Open();
            MySqlCommand mcActTipoRecurso;
            try
            {
                if (TipRec != null)
                {
                    mcActTipoRecurso = new MySqlCommand("actualizartiporecurso", con);
                    mcActTipoRecurso.CommandType = CommandType.StoredProcedure;
                    mcActTipoRecurso.Parameters.AddWithValue("@codigo", TipRec.CodigoTipoRecurso);
                    mcActTipoRecurso.Parameters.AddWithValue("@nombre", TipRec.NombreTipoRecurso);
                    mcActTipoRecurso.Parameters.AddWithValue("@estado", TipRec.EstadoTipoRecurso);
                    mcActTipoRecurso.ExecuteNonQuery();
                    MessageBox.Show("EL TIPO DE RECURSO" + TipRec.NombreTipoRecurso + " SE ACTUALIZO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void EliminarTipoRecurso(clsTipoRecurso TipRec)
        {
            con.Open();
            MySqlCommand mcEliTipoRecurso;
            try
            {
                if (TipRec != null)
                {
                    mcEliTipoRecurso = new MySqlCommand("eliminartiporecurso", con);
                    mcEliTipoRecurso.CommandType = CommandType.StoredProcedure;
                    mcEliTipoRecurso.Parameters.AddWithValue("@codigo", TipRec.CodigoTipoRecurso);
                    mcEliTipoRecurso.ExecuteNonQuery();
                    MessageBox.Show("LOS DATOS SE ELIMINARON EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
