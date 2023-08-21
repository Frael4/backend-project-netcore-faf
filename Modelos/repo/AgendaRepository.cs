using Modelos.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelos.repo
{
    public class AgendaRepository
    {

        private readonly string connectionString;
        public AgendaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /**/
        public async Task<List<Agenda>> ListarAgendasPartidos(string type, string filtro)
        {
            List<Agenda>? listaNueva = null;
            string sp_name = StoreProceduresNames.AG_SP_CONS;
            string transaccion = type;

            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, filtro);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                listaNueva = new List<Agenda>();

                using (DataTable table = dataSet.Tables[0])
                {
                    foreach (DataRow row in table.Rows)
                    {
                        listaNueva.Add(

                         new Agenda
                         {
                             Id = int.Parse((row["id_agenda"].ToString()!)),
                             FechaPartido = DateTime.Parse(row["fecha_partido"].ToString()!),
                             Lugar = (row["lugar_partido"].ToString()!),
                             HoraPartido = (row["hora_partido"].ToString()!),
                             Partido = new Partido
                             {
                                 IdPartido = int.Parse(row["partido_id_partido"].ToString()!),
                                 EquipoLocal = new Equipo
                                 {
                                     Id = int.Parse(row["club_id_local"].ToString()!),
                                     Nombre = (row["nombre_local"].ToString()!)
                                 },
                                 EquipoRival = new Equipo
                                 {
                                     Id = int.Parse(row["club_id_rival"].ToString()!),
                                     Nombre = (row["nombre_rival"].ToString()!)
                                 }
                             }
                         });

                    }
                }
            }

            if (filtro != "")
            {
                //Console.WriteLine(filtro);
                Console.WriteLine("Filtrando lista");
                listaNueva = listaNueva?.FindAll(a => a.Lugar?.ToUpper().IndexOf(filtro.ToUpper()) > -1
                || a.Partido?.EquipoLocal?.Nombre?.ToUpper().IndexOf(filtro.ToUpper()) > -1
                || a.Partido?.EquipoRival?.Nombre?.ToUpper().IndexOf(filtro.ToUpper()) > -1);

            }
            //return JsonConverter.SerializeObject( listaNueva);
            return (listaNueva);
        }

        public async Task<Agenda> GetAgendaPartido(Agenda agenda)
        {
            Agenda? tmp = null;
            string transaccion = "CONSULTA_AGENDA_PARTIDO";

            XDocument dataXML = DBXmlMethods.GetXml(agenda);
            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(StoreProceduresNames.AG_SP_CONS, this.connectionString, transaccion, dataXML.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {

                using (DataTable table = dataSet.Tables[0])
                {
                    foreach (DataRow row in table.Rows)
                    {
                        tmp = new Agenda
                        {
                            Id = int.Parse((row["id_agenda"].ToString()!)),
                            FechaPartido = DateTime.Parse(row["fecha_partido"].ToString()!),
                            Lugar = (row["lugar_partido"].ToString()!),
                            HoraPartido = (row["hora_partido"].ToString()!),
                            Sorteado = (row["sorteado"].ToString()!),
                            Partido = new Partido { IdPartido = int.Parse(row["partido_id_partido"].ToString()!) }

                        };
                    }
                }
            }
            return tmp;
        }

        public async Task<Respuesta> MantAgendaPartido(Agenda agenda, string transaccion)
        {
            string sp_name = StoreProceduresNames.AG_SP_MANT;
            Respuesta? res = new();

            XDocument xmlData = DBXmlMethods.GetXml(agenda);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                res.Error = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                res.Response = dataSet?.Tables[0]?.Rows[0]["RESPONSE"].ToString();
            }

            return res;
        }
    }
}
