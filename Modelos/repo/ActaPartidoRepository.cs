using Modelos.Shared;
using System.Data;
using System.Xml.Linq;

namespace Modelos.repo
{
    public class ActaPartidoRepository
    {
        private readonly string connectionString;
        public ActaPartidoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /**/
        public async Task<List<ActaPartido>> ListarActasPartido(string type, string filtro)
        {
            List<ActaPartido>? listaNueva = null;
            string sp_name = StoreProceduresNames.AP_SP_CONS;
            //string transaccion = "CONSULTAR_ALL_ACTAS_PARTIDO";
            string transaccion = type;

            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, filtro);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                listaNueva = new List<ActaPartido>();

                using (DataTable table = dataSet.Tables[0])
                {
                    foreach (DataRow row in table.Rows)
                    {
                        listaNueva.Add(

                         new ActaPartido
                         {
                             Id = int.Parse((row["id_acta_partido"].ToString()!)),
                             FechaEmision = DateTime.Parse(row["fecha_emision_acta"].ToString()!),
                             HoraInicio = row["hora_inicio_partido"].ToString(),
                             HoraFin = row["hora_fin_partido"].ToString(),
                             EquipoLocal = row["nombre_local"].ToString(),
                             EquipoRival = row["nombre_rival"].ToString(),
                             DuracionPartido = row["duracion_partido"].ToString(),
                             NumGolEquipoLocal = int.Parse(row["num_gol_equipo_local"].ToString()!),
                             NumGolEquipoRival = int.Parse(row["num_gol_equipo_rival"].ToString()!),
                             EquipoGanador = row["equipo_ganador"].ToString(),
                             /*Partido = row["partido_descripcion"].ToString(),*/
                             Partido = new Partido
                             {
                                 IdPartido = int.Parse(row["partido_id_partido"].ToString()!),
                                 PartidoDescripcion = row["partido_descripcion"].ToString()
                             }
                         });

                    }
                }
            }

            if (filtro != "")
            {
                //Console.WriteLine(filtro);
                Console.WriteLine("Filtrando lista");
                listaNueva = listaNueva?.FindAll(a => a.EquipoRival?.ToUpper().IndexOf(filtro.ToUpper()) > -1 || a.EquipoLocal?.ToUpper().IndexOf(filtro.ToUpper()) > -1);

            }
            //return JsonConverter.SerializeObject( listaNueva);
            return (listaNueva);
        }

        /**/
        public async Task<Respuesta> CreateActaPartido(ActaPartido actaPartido)
        {
            string sp_name = StoreProceduresNames.AP_SP_MANT;
            string transaccion = "CREAR_ACTA_PARTIDO";
            Respuesta? res = new();

            XDocument xmlData = DBXmlMethods.GetXml(actaPartido);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                res.Error = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                res.Response = dataSet?.Tables[0]?.Rows[0]["RESPONSE"].ToString();
            }

            return res;
        }

        /* */
        public async Task<Respuesta> UpdateActaPartido(ActaPartido actaPartido)
        {
            string sp_name = StoreProceduresNames.AP_SP_MANT;
            string transaccion = "ACTUALIZAR_ACTA_PARTIDO";
            Respuesta? res = new();

            XDocument xmlData = DBXmlMethods.GetXml(actaPartido);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                res.Error = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                res.Response = dataSet?.Tables[0]?.Rows[0]["RESPONSE"].ToString();
            }

            return res;

        }

        /**/
        public async Task<Respuesta> DeleteActaPartido(ActaPartido actaPartido)
        {
            string sp_name = StoreProceduresNames.AP_SP_MANT;
            string transaccion = "ELIMINAR_ACTA_PARTIDO";

            Respuesta? res = new();

            XDocument xmlData = DBXmlMethods.GetXml(actaPartido);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                res.Error = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                res.Response = dataSet?.Tables[0]?.Rows[0]["RESPONSE"].ToString();
            }

            return res;

        }

        public async Task<ActaPartido> GetActaPartido(ActaPartido acta)
        {
            ActaPartido? actaPartido = null;
            string transaccion = "CONSULTA_ACTA_PARTIDO";

            XDocument dataXML = DBXmlMethods.GetXml(acta);
            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(StoreProceduresNames.AP_SP_CONS, this.connectionString, transaccion, dataXML.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {

                using (DataTable table = dataSet.Tables[0])
                {
                    actaPartido = new ActaPartido
                    {
                        Id = int.Parse((table.Rows[0]["id_acta_partido"].ToString()!)),
                        FechaEmision = DateTime.Parse(table.Rows[0]["fecha_emision_acta"].ToString()!),
                        HoraInicio = table.Rows[0]["hora_inicio_partido"].ToString(),
                        HoraFin = table.Rows[0]["hora_fin_partido"].ToString(),
                        EquipoLocal = table.Rows[0]["nombre_local"].ToString(),
                        EquipoRival = table.Rows[0]["nombre_rival"].ToString(),
                        DuracionPartido = table.Rows[0]["duracion_partido"].ToString(),
                        NumGolEquipoLocal = int.Parse(table.Rows[0]["num_gol_equipo_local"].ToString()!),
                        NumGolEquipoRival = int.Parse(table.Rows[0]["num_gol_equipo_rival"].ToString()!)

                    };
                }
            }
            return actaPartido;
        }


        public async Task<List<Partido>> GetComboPartido(string? transaccion = "")
        {
            List<Partido>? partidos = null;

            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(StoreProceduresNames.AP_SP_COMBO_PARTIDO, this.connectionString, transaccion!);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                partidos = new List<Partido>();
                using (DataTable table = dataSet.Tables[0])
                {
                    foreach (DataRow row in table.Rows)
                    {
                        partidos.Add(

                         new Partido()
                         {
                             IdPartido = int.Parse((row["id_partido"].ToString())),
                             PartidoDescripcion = row["partido_descripcion"].ToString()
                         });

                    }
                }
            }

            return partidos;
        }


    }
}
