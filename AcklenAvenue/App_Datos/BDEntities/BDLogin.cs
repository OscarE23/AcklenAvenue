using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AcklenAvenue
{
    public class BDLogin
    {
        public BDLogin()
        {
        }
        //INSERTAR
        public bool Registrarse(string Nombre, string Apellidos, string Usuario, string Contraseña)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 1),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Apellidos", Apellidos),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
            };
                DataTable registro = new ClsSQL().ExecuteSp("ProcedureAcklen", param);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        //VALIDACIÓN DE SESIÓN
        public DataTable ValidarSesion(string Usuario, string Contraseña)
        {
            DataTable registro;
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {              
                new SqlParameter("@Accion", 2),
                new SqlParameter("@Usuario", Usuario),
                new SqlParameter("@Contraseña", Contraseña),
            };
                registro = new ClsSQL().ExecuteSp("ProcedureAcklen", param);
            }
            catch (Exception e)
            {
                registro = null;
            }
            return registro;
        }

    }
}