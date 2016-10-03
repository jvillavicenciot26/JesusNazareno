using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using JesusNazareno.Model;
using System.Windows.Forms;

namespace JesusNazareno.Controller
{
    class clsAccesoRecursos
    {
        MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
        //MySqlConnection con = new MySqlConnection("server=191.234.183.224; Uid=root; Password=bitnami; Database=iejesusnazareno; Port=3306");

        public DataTable ConsultarTodoRecursos()
        {
            con.Open();
            MySqlDataAdapter mdaRecursos = new MySqlDataAdapter();
            DataTable dtRecurso = new DataTable();
            try
            {
                mdaRecursos.SelectCommand = new MySqlCommand("consultatodorecursos", con);
                mdaRecursos.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaRecursos.Fill(dtRecurso);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtRecurso;
        }

        public DataTable FiltrarRecursos(string buscarpor, string parametro)
        {
            con.Open();
            MySqlCommand mcFilRecursos;
            MySqlDataAdapter mdaFilRecursos = new MySqlDataAdapter();
            DataTable dtFilRecursos = new DataTable();
            try
            {
                mcFilRecursos = new MySqlCommand("filtrarrecursos", con);
                mcFilRecursos.CommandType = CommandType.StoredProcedure;
                mcFilRecursos.Parameters.AddWithValue("@buscarpor", buscarpor);
                mcFilRecursos.Parameters.AddWithValue("@param", parametro);
                mdaFilRecursos.SelectCommand = mcFilRecursos;
                mdaFilRecursos.Fill(dtFilRecursos);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtFilRecursos;
        }

        public DataTable LlenarComboTipoRecursos()
        {
            con.Open();
            MySqlDataAdapter mdaComboTipoRecursos = new MySqlDataAdapter();
            DataTable dtComboTipoRecursos = new DataTable();
            try
            {
                mdaComboTipoRecursos.SelectCommand = new MySqlCommand("llenarcombotiporecursos", con);
                mdaComboTipoRecursos.SelectCommand.CommandType = CommandType.StoredProcedure;
                mdaComboTipoRecursos.Fill(dtComboTipoRecursos);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dtComboTipoRecursos;
        }

        public void RegistrarRecursos(clsRecurso Rec)
        {
            con.Open();
            MySqlCommand mcRegRecurso;
            try
            {
                if (Rec != null)
                {
                    mcRegRecurso = new MySqlCommand("registrarrecurso", con);
                    mcRegRecurso.CommandType = CommandType.StoredProcedure;
                    mcRegRecurso.Parameters.AddWithValue("@codigo", Rec.CodigoRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@nombre", Rec.NombreRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@serie", Rec.SerieRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@estado", Rec.EstadoRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@marca", Rec.MarcaRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@tiporecurso", Rec.CodigoTipRecurso);
                    mcRegRecurso.ExecuteNonQuery();
                    MessageBox.Show("EL RECURSO " + Rec.NombreRecurso + " SE REGISTRO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ActualizarRecursos(clsRecurso Rec)
        {
            con.Open();
            MySqlCommand mcRegRecurso;
            try
            {
                if (Rec != null)
                {
                    mcRegRecurso = new MySqlCommand("actualizarrecurso", con);
                    mcRegRecurso.CommandType = CommandType.StoredProcedure;
                    mcRegRecurso.Parameters.AddWithValue("@codigo", Rec.CodigoRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@nombre", Rec.NombreRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@serie", Rec.SerieRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@estado", Rec.EstadoRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@marca", Rec.MarcaRecurso);
                    mcRegRecurso.Parameters.AddWithValue("@tiporecurso", Rec.CodigoTipRecurso);
                    mcRegRecurso.ExecuteNonQuery();
                    MessageBox.Show("EL RECURSO " + Rec.NombreRecurso + " SE ACTUALIZO EXITOSAMENTE", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void EliminarRecurso(clsRecurso Rec)
        {
            con.Open();
            MySqlCommand mcEliRecurso;
            try
            {
                if (Rec != null)
                {
                    mcEliRecurso = new MySqlCommand("eliminarrecurso", con);
                    mcEliRecurso.CommandType = CommandType.StoredProcedure;
                    mcEliRecurso.Parameters.AddWithValue("@codigo", Rec.CodigoRecurso);
                    mcEliRecurso.ExecuteNonQuery();
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

        public clsRecurso BuscarRecurso(int codigo)
        {
            con.Open();
            clsRecurso Rec = new clsRecurso();
            MySqlCommand mcBusRecurso;
            try
            {
                mcBusRecurso = new MySqlCommand("buscarrecurso", con);
                mcBusRecurso.CommandType = CommandType.StoredProcedure;
                mcBusRecurso.Parameters.AddWithValue("@codigo", codigo);
                MySqlDataReader mdrRecurso = mcBusRecurso.ExecuteReader();
                if (mdrRecurso.HasRows)
                {
                    while (mdrRecurso.Read())
                    {
                        Rec.NombreRecurso = mdrRecurso.GetString(0);
                        int serie = mdrRecurso.GetOrdinal("SerieRecurso");
                        if (mdrRecurso.IsDBNull(serie))
                        {
                            MessageBox.Show("NO EXISTE SERIE PARA ESTE PERSONAL", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Rec.SerieRecurso = string.Empty;
                        }
                        else
                        {
                            Rec.SerieRecurso = mdrRecurso.GetString(1);
                        }
                        //Rec.SerieRecurso = mdrRecurso.IsDBNull(serie) ? string.Empty : mdrRecurso.GetString(1);
                        Rec.EstadoRecurso = mdrRecurso.GetString(2);
                        int marca = mdrRecurso.GetOrdinal("MarcaRecurso");
                        if (mdrRecurso.IsDBNull(marca))
                        {
                            MessageBox.Show("NO EXISTE MARCA PARA ESTE PERSONAL", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Rec.MarcaRecurso = string.Empty;
                        }
                        else
                        {
                            Rec.MarcaRecurso = mdrRecurso.GetString(3);
                        }
                        //Rec.MarcaRecurso = mdrRecurso.IsDBNull(marca) ? string.Empty : mdrRecurso.GetString(3);
                        Rec.CodigoTipRecurso = mdrRecurso.GetInt32(4);
                    }
                    MessageBox.Show("DATOS ENCONTRADOS", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO EXISTEN DATOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mdrRecurso.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return Rec;
        }
    }
}
