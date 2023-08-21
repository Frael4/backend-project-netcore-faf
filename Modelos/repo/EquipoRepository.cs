using Modelos.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modelos.repo
{
    public class EquipoRepository
    {

        private readonly string connectionString;
        public EquipoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /**/
        public async Task<List<Equipo>> GetEquipos(string type, string filtro)
        {
            List<Equipo>? listaNueva = null;
            string sp_name = StoreProceduresNames.EQ_SP_CONS;
            string transaccion = type;

            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, filtro);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                listaNueva = new List<Equipo>();

                using (DataTable table = dataSet.Tables[0])
                {
                    foreach (DataRow row in table.Rows)
                    {
                        listaNueva.Add(

                         new Equipo
                         {
                             Id = int.Parse((row["id_club"].ToString()!)),
                             Nombre = (row["nombre"].ToString()!),
                             Director = (row["director"].ToString()!)
                         }

                         );

                    }
                }
            }

            if (filtro != "")
            {
                //Console.WriteLine(filtro);
                Console.WriteLine("Filtrando lista");
                listaNueva = listaNueva?.FindAll(a => a.Director?.ToUpper().IndexOf(filtro.ToUpper()) > -1 || a.Nombre?.ToUpper().IndexOf(filtro.ToUpper()) > -1);

            }
            //return JsonConverter.SerializeObject( listaNueva);
            return (listaNueva);
        }

        public async Task<Equipo> GetEquipo(Equipo equipo)
        {
            Equipo? tmp = null;
            string transaccion = "CONSULTA_EQUIPO";

            XDocument dataXML = DBXmlMethods.GetXml(equipo);
            // Obtencion del data set
            DataSet dataSet = await DBXmlMethods.EjecutaBase(StoreProceduresNames.EQ_SP_CONS, this.connectionString, transaccion, dataXML.ToString());

            if (dataSet.Tables[0].Rows.Count > 0)
            {

                using (DataTable table = dataSet.Tables[0])
                {
                    tmp = new Equipo
                    {
                        Id = int.Parse((table.Rows[0]["id_acta_partido"].ToString()!)),
                        Nombre = (table.Rows[0]["nombre"].ToString()!),
                        Director = (table.Rows[0]["director"].ToString()!)

                    };
                }
            }
            return tmp;
        }

        public async Task<Respuesta> MantEquipo(Equipo equipo, string transaccion)
        {
            string sp_name = StoreProceduresNames.EQ_SP_MANT;
            Respuesta? res = new();

            XDocument xmlData = DBXmlMethods.GetXml(equipo);
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
