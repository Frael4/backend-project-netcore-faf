using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace Modelos.Shared
{
    public class DBXmlMethods
    {

        public static XDocument GetXml<T>(T criterio)
        {
            XDocument resultado = new XDocument(new XDeclaration("1.0", "utf-8", "true"));
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using XmlWriter xw = resultado.CreateWriter();
                xs.Serialize(xw, criterio);
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return resultado;
            }
        }

        public static async Task<DataSet> EjecutaBase(string nombreProcedimiento, string cadenaConexion, string transaccion, string? dataXML = null, string? filtro = null)
        {
            DataSet dsResultado = new DataSet();
            try
            {
                using SqlConnection cnn = new SqlConnection(cadenaConexion);
                using SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adt = new SqlDataAdapter();
                cmd.CommandText = nombreProcedimiento;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                cmd.CommandTimeout = 120;
                cmd.Parameters.Add("@Transaccion", SqlDbType.VarChar).Value = transaccion;
                cmd.Parameters.Add("@dataXml", SqlDbType.Xml).Value = dataXML?.ToString();
                //cmd.Parameters.Add("@FILTRO", SqlDbType.Xml).Value = filtro!;
                await cnn.OpenAsync().ConfigureAwait(false);
                adt = new SqlDataAdapter(cmd);
                adt.Fill(dsResultado);
                //cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en " + ex.Message);
                Console.Write("Logs EjecutaBase " + ex.ToString());
            }
            
            return dsResultado;
        }
    }
}
