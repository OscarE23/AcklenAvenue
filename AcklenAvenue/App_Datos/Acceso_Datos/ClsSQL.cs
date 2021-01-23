using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AcklenAvenue
{
    public class ClsSQL
    {
        private SqlConnection cn;
        SqlTransaction transaction;

        public ClsSQL()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //

            try
            {
                this.CrearConexion();
                this.AbirConexion();
            }


            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex.InnerException);
            }

        }

        /// <summary>
        /// Crea la conexión
        /// </summary>
        private void CrearConexion()
        {

            string cadena = ConfigurationManager.AppSettings["Conexion"];
            this.cn = new SqlConnection(cadena);
        }

        /// <summary>
        /// Abre la conexión
        /// </summary>
        private void AbirConexion()
        {
            this.cn.Open();
        }
        /// <summary>
        /// Cierra la conexión
        /// </summary>
        public void ConexClose()
        {
            this.cn.Close();
        }

        /// <summary>
        /// método para Ejecutar un sp normal
        /// </summary>

        public DataTable ExecuteSp(string sp, List<SqlParameter> args)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd;

            cmd = new SqlCommand(sp, this.cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(args.ToArray());

            SqlDataAdapter dta = new SqlDataAdapter(cmd);
            dta.Fill(dt);
            this.ConexClose();
            return dt;


        }

        /// <summary>
        /// método para Ejecutar un sp con transaction
        /// </summary>
        public DataTable ExecuteSpTransaction(string sp, List<SqlParameter> args)
        {
            DataTable dt = new DataTable();
            try
            {

                transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);

                SqlCommand cmd;

                cmd = new SqlCommand(sp, this.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.Parameters.AddRange(args.ToArray());

                SqlDataAdapter dta = new SqlDataAdapter(cmd);
                dta.Fill(dt);
                return dt;

            }
            catch (Exception)
            {
                transaction.Rollback();
                return dt;
            }
            finally
            {

                transaction.Commit();
                ConexClose();

            }
        }

        public bool ExecuteQuery(string query)
        {
            SqlTransaction transaction;
            transaction = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                //transaction.Connection = connection;
                SqlCommand command = new SqlCommand(query, cn);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 0;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException sqlerr)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                transaction.Commit();
                cn.Close();
                cn.Dispose();
            }
        }

        public DataTable ExecuteTable(String query)
        {
            DataTable Tabla = new DataTable();
            string information = string.Empty;
            //connection.Open();

            SqlDataAdapter result = new SqlDataAdapter(query, cn);
            result.SelectCommand.CommandTimeout = 0;

            try
            {
                result.Fill(Tabla);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();

            }
            return Tabla;
        }
    }
}