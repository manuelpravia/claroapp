using Claro.Pagos.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Provider;

namespace Claro.Pagos.DAC
{
    public class TipoPagoDAC : ITipoPagoDAC
    {
        public bool Insertar(TipoPagoBE entity)
        {

                bool rpta = false;
                try
                {

                    //string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                    string cadenaConexion = "Data Source=MANUEL\\SQLEXPRESS;Initial Catalog=CLAROBD;Persist Security Info=True;User ID=sa;Password=123456789 providerName = System.Data.SqlClient";
                    string str = "InsertarTipoPago";

                    using (SqlConnection conn = new SqlConnection(cadenaConexion))
                    {
                        SqlCommand cmd = new SqlCommand(str, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@cFormaPago", SqlDbType.VarChar).SqlValue = entity.formaPago;
                        cmd.Parameters.Add("@cNumeroDocumento", SqlDbType.NVarChar).SqlValue = entity.numeroDocumento;
                        cmd.Parameters.Add("@cmontoPagado", SqlDbType.Decimal).SqlValue = entity.montoPagado;
                    cmd.Parameters.Add("@nIdPago",SqlDbType.Int).SqlValue=entity.pagoID;
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
