using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace AcklenAvenue
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string Insertar(string Nombre, string Apellidos, string Usuario, string Contraseña)
        {
            BDLogin BD = new BDLogin();
            bool respuesta = BD.Registrarse(Nombre, Apellidos, Usuario, Contraseña);

            if (respuesta == true)
            {
                return "Correcto";
            }
            return "Falso";
        }

        [WebMethod]
        public static string Sesion(string Usuario, string Contraseña)
        {
            BDLogin BD = new BDLogin();
            DataTable respuesta = BD.ValidarSesion(Usuario, Contraseña);

            if (respuesta != null && respuesta.Rows.Count != 0)
            {
                return "Correcto";
            }
            return "Falso";
        }
    }
}