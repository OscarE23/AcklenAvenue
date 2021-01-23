using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AcklenAvenue.App_Datos.BDEntities
{
    public class BDProductos
    {
        public BDProductos()
        {
        }

        //LLENAR GRID
        public DataTable Grid()
        {
            DataTable registro;
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {              
                new SqlParameter("@Accion", 1)
            };
                registro = new ClsSQL().ExecuteSp("ProductosAcklen", param);
            }
            catch (Exception e)
            {
                registro = null;
            }
            return registro;
        }

        //INSERTAR PRODUCTO
        public bool InsertarProducto(string Nombre, string Precio, string Existencia)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 2),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Precio", Precio),
                new SqlParameter("@Existencia", Existencia),
            };
                DataTable registro = new ClsSQL().ExecuteSp("ProductosAcklen", param);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        //EDITAR PRODUCTO
        public bool ActualizarProducto(string Nombre, string Precio, string Existencia, int Id)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 3),
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Precio", Precio),
                new SqlParameter("@Existencia", Existencia),
                new SqlParameter("@Id", Id),

            };
                DataTable registro = new ClsSQL().ExecuteSp("ProductosAcklen", param);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        //CONSULTAR PRODUCTO MEDIANTE EL ID
        public DataTable ProductoMedianteID(int Id)
        {
            DataTable registro;
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {              
                new SqlParameter("@Accion", 4),
                new SqlParameter("@Id", Id),
            };
                registro = new ClsSQL().ExecuteSp("ProductosAcklen", param);
            }
            catch (Exception e)
            {
                registro = null;
            }
            return registro;
        }

        //ELIMINAR PRODUCTO
        public bool EliminarProducto(int Id)
        {
            try
            {
                List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter("@Accion", 5),
                new SqlParameter("@Id", Id),

            };
                DataTable registro = new ClsSQL().ExecuteSp("ProductosAcklen", param);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

    }

    
}