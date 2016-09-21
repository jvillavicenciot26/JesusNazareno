using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesusNazareno.Model
{
    public class clsLogin
    {
        String usuario;
        String clave;

        public clsLogin(String usuario, String clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }

        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public string Clave
        {
            get { return this.clave; }
            set { this.clave = value; }
        }

    }
}
