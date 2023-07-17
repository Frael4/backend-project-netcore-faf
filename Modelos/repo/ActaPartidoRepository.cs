using Microsoft.Data.SqlClient;
using Modelos.Shared;
using System.Data;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Modelos.repo
{
    public class ActaPartidoRepository
    {
        private readonly string connectionString;
        public ActaPartidoRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        /**/
        public async Task<IEnumerable<ActaPartido>> ListarActasPartido()
        {
            List<ActaPartido> listaNueva = new List<ActaPartido>();
            string sp_name = StoreProceduresNames.AP_SP_CONS;
            string transaccion = "CONSULTAR_ALL_ACTAS_PARTIDO";

            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion);

            using (DataTable table = dataSet.Tables[0])
            {
                foreach (DataRow row in table.Rows)
                {
                    listaNueva.Add(
                        new ActaPartido
                        {
                            Id = int.Parse(row["id_acta_partido"].ToString()),
                            FechaEmision = DateTime.Parse(row["fecha_emision_acta"].ToString())
                        }
                        );
                    ;
                }
            }


            //return JsonConverter.SerializeObject( listaNueva);
            return listaNueva;
        }


        /**/
        public async Task<string> CreateActaPartido(ActaPartido actaPartido)
        {
            string sp_name = StoreProceduresNames.AP_SP_MANT;
            string transaccion = "CREAR_ACTA_PARTIDO";
            string? mensaje = "";

            XDocument xmlData = DBXmlMethods.GetXml(actaPartido);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());

            if (dataSet.Tables.Count > 0)
            {
                mensaje = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                return mensaje;
            }

            return mensaje;
        }

        /* */
        public async Task<string> UpdateActaPartido(ActaPartido actaPartido)
        {
            string sp_name = StoreProceduresNames.AP_SP_MANT;
            string transaccion = "ACTUALIZAR_ACTA_PARTIDO";
            string? mensaje = "";
            
            XDocument xmlData = DBXmlMethods.GetXml(actaPartido);
            DataSet dataSet =await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());
            if(dataSet.Tables.Count > 0)
            {
                mensaje = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                return mensaje;
            }

            return mensaje;

        }

        public async Task<string> DeleteActaPartido(ActaPartido actaPartido)
        {
            string sp_name = StoreProceduresNames.AP_SP_MANT;
            string transaccion = "ELIMINAR_ACTA_PARTIDO";
            string? mensaje = "";

            XDocument xmlData = DBXmlMethods.GetXml(actaPartido);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());
            if (dataSet.Tables.Count > 0)
            {
                mensaje = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                return mensaje;
            }

            return mensaje;

        }
    }
}
