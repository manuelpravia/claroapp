using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claro.Pagos.DAC
{
    public class PagoDAC : IPagoDAC
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                //string cadenaConexion = "Data Source=TRJ-8NYCNG3\\SQLEXPRESS;Initial Catalog=BDCliente;Persist Security Info=True;User ID=sa;Password=Xfile$3000";
                string str = "dbo.uspDeleteClientBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_ID", SqlDbType.Int).SqlValue = id;
                    cmd.Parameters.Add("@PO_OUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    rpta = (bool.Parse(cmd.Parameters["@PO_OUT"].Value.ToString()));
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                rpta = false;
            }
            catch (Exception ex2)
            {
                rpta = false;
            }

            return rpta;
        }

        public PagoBE Get(int id)
        {
            PagoBE entity = null;

            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string str = "dbo.uspGetClientBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_ID", SqlDbType.Int).SqlValue = id;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity = new PagoBE();
                            entity.cliente = reader["cliente"].ToString();
                            entity.importe = Convert.ToDecimal(reader["nombre"].ToString());
                            entity.saldo = Convert.ToDecimal(reader["apellido"].ToString());
                            entity.tipoComprobante = reader["edad"].ToString();
                            entity.fecha = Convert.ToDateTime(reader["genero"].ToString());
                            //entity.formaPago = reader["nacionalidad"].ToString();
                            //entity.numeroDocumento = reader["genero"].ToString();
                            //entity.montoPagado = Convert.ToDecimal(reader["nacionalidad"].ToString());

                        }
                    }
                    reader.Close();
                    conn.Close();
                }



            }
            catch (SqlException ex)
            {
                entity = null;
            }
            catch (Exception ex2)
            {
                entity = null;
            }

            return entity;
        }

        public int Insertar(PagoBE entity)
        {
            int rpta = -1;
            try
            {

                //string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string cadenaConexion = "Data Source=MANUEL\\SQLEXPRESS;Initial Catalog=CLAROBD;Persist Security Info=True;User ID=sa;Password=123456789 providerName = System.Data.SqlClient";
                string str = "InsertarPago";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cCliente", SqlDbType.NVarChar, 100).SqlValue = entity.cliente;
                    cmd.Parameters.Add("@cImporte", SqlDbType.Decimal).SqlValue = entity.importe;
                    cmd.Parameters.Add("@cSaldo", SqlDbType.Decimal).SqlValue = entity.saldo;
                    cmd.Parameters.Add("@cTipoComprobante", SqlDbType.NVarChar).SqlValue = entity.tipoComprobante;
                    cmd.Parameters.Add("@cFecha", SqlDbType.DateTime).SqlValue = entity.fecha;
                    cmd.Parameters.Add("@nIdPagoNuevo", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    rpta = Convert.ToInt32(cmd.Parameters["@nIdPagoNuevo"].Value.ToString());
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                rpta = -1;
            }
            catch (Exception ex2)
            {
                rpta = -1;
            }

            return rpta;
        }

        public List<PagoBE> Listar(PagoBE entity)
        {
            List<PagoBE> list = null;

            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string str = "dbo.uspListClientBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        PagoBE objClient = null;
                        list = new List<PagoBE>();
                        while (reader.Read())
                        {
                            objClient = new PagoBE();
                            objClient.cliente = reader["cliente"].ToString();
                            objClient.importe = Convert.ToDecimal(reader["nombre"].ToString());
                            objClient.saldo = Convert.ToDecimal(reader["apellido"].ToString());
                            objClient.tipoComprobante = reader["edad"].ToString();
                            objClient.fecha = Convert.ToDateTime(reader["genero"].ToString());
                            //objClient.formaPago = reader["nacionalidad"].ToString();
                            //objClient.numeroDocumento = reader["genero"].ToString();
                            //objClient.montoPagado = Convert.ToDecimal(reader["nacionalidad"].ToString());

                            list.Add(objClient);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }



            }
            catch (SqlException ex)
            {
                list = null;
            }
            catch (Exception ex2)
            {
                list = null;
            }

            return list;
        }

        public bool Update(PagoBE entity)
        {
            bool rpta = false;
            try
            {

                string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string str = "dbo.uspUpdateClientBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_CLIENTE", SqlDbType.NVarChar, 100).SqlValue = entity.cliente;
                    cmd.Parameters.Add("@PI_IMPORTE", SqlDbType.NVarChar, 100).SqlValue = entity.importe;
                    cmd.Parameters.Add("@PI_SALDO", SqlDbType.Int).SqlValue = entity.saldo;
                    cmd.Parameters.Add("@PI_TIPOCOMPROBANTE", SqlDbType.NVarChar, 5).SqlValue = entity.tipoComprobante;
                    cmd.Parameters.Add("@PI_FECHA", SqlDbType.NVarChar, 5).SqlValue = entity.fecha;
                    //cmd.Parameters.Add("@PI_FORMAPAGO", SqlDbType.Int).SqlValue = entity.formaPago;
                    //cmd.Parameters.Add("@PI_NUMERODOCUMENTO", SqlDbType.NVarChar, 5).SqlValue = entity.numeroDocumento;
                    //cmd.Parameters.Add("@PI_MONTOPAGADO", SqlDbType.NVarChar, 5).SqlValue = entity.montoPagado;
                    cmd.Parameters.Add("@PO_OUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    rpta = (bool.Parse(cmd.Parameters["@PO_OUT"].Value.ToString()));
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                rpta = false;
            }
            catch (Exception ex2)
            {
                rpta = false;
            }

            return rpta;
        }
    }
}
