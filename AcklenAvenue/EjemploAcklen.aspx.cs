using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AcklenAvenue.App_Datos.BDEntities;
using System.Web.Services;

namespace AcklenAvenue
{
    public partial class EjemploAcklen : System.Web.UI.Page
    {
        public static DataTable registro = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarGrid();
                if (registro != null)
                {
                    viewGrid.Visible = false;
                    viewCampos.Visible = true;
                }
                else
                {
                    viewGrid.Visible = true;
                    viewCampos.Visible = false;
                }
                
            }
        }

        //CARGAR GRID UNIDADES
        public void CargarGrid()
        {
            try
            {
                registro = null;
                BDProductos BD = new BDProductos();
                DataTable Productos = BD.Grid();
                dgvProductos.DataSource = Productos;
                dgvProductos.DataBind();
            }

            catch (Exception)
            {
                return;
            }
        }

        //INSERTAR PRODUCTO
        [WebMethod]
        public static string InsertarProducto(string Nombre, string Precio, string Existencia)
        {
            BDProductos BD = new BDProductos();
            //Registrar
            if (registro == null)
            {
                bool respuesta = BD.InsertarProducto(Nombre, Precio, Existencia);

                if (respuesta == true)
                {
                    return "Correcto";
                    //registro = null;
                }
                return "Falso";
            }
            //Editar
            else
            {
                bool respuesta = BD.ActualizarProducto(Nombre, Precio, Existencia, int.Parse(registro.Rows[0]["Id"].ToString()));

                if (respuesta == true)
                {
                    return "Correcto";
                    //registro = null;
                }
                return "Falso";
            }
        }

        //EDITAR PRODUCTO
        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string str = null;
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvProductos.Rows[index];

                str = row.Cells[0].Text;

                BDProductos BD = new BDProductos();
                //Consultar Producto mediante el Id

                registro = BD.ProductoMedianteID(int.Parse(str));
                txtNombre.Text = registro.Rows[0]["Nombre"].ToString();
                txtPrecio.Text = registro.Rows[0]["Precio"].ToString();
                txtExistencia.Text = registro.Rows[0]["Existencia"].ToString();

                viewGrid.Visible = false;
                viewCampos.Visible = true;

                //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_info('Registro eliminado','');", true);

            }

            else if (e.CommandName == "Eliminar")//Eliminar producto
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dgvProductos.Rows[index];

                str = row.Cells[0].Text;

                BDProductos BD = new BDProductos();
                BD.EliminarProducto(int.Parse(str));
                CargarGrid();

            }
        }

        //Boton de regresar
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            viewGrid.Visible = true;
            viewCampos.Visible = false;
            limpiar();
        }

        //Limpiar Campos
        public void limpiar()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
            registro = null;
        }

        //Boton agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            viewGrid.Visible = false;
            viewCampos.Visible = true;
        }

    }
}