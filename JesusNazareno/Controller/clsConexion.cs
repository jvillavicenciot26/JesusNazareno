using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace JesusNazareno.Controller
{
    public class clsConexion
    {
        public MySqlConnection ConectarBD()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; Uid=root; Password=root; Database=iejesusnazareno; Port=3306");
            return con;
        }
    }
}
