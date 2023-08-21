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
    public class ArbitroRepository
    {
        private readonly string connectionString;
        public ArbitroRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Arbitro>> ListarArbitro()
        {
            List<Arbitro> listaNueva = new List<Arbitro>();
            string sp_name = StoreProceduresNames.AB_SP_CONS;
            string transaccion = "CONSULTAR_TDS_ARBITRO";

            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion);

            using (DataTable table = dataSet.Tables[0])
            {
                foreach (DataRow row in table.Rows)
                {
                    listaNueva.Add(
                        new Arbitro
                        {
                            Id = int.Parse(row["id_arbitro"].ToString()),
                            Categoria = (row["categoria"].ToString()),
                            Nombre = (row["nombre"].ToString()),
                            Apellido = (row["apellido"].ToString()),
                            Email = (row["email"].ToString()),
                            NombreUsuario = (row["nombre_usuario"].ToString()),
                            Contrasenia = (row["contrasenia"].ToString()),
                            Edad = int.Parse(row["edad"].ToString()),
                            Nacionalidad = (row["nacionalidad"].ToString()),
                            CantidadPartidos = int.Parse(row["cantidad_partidos"].ToString()),
                        }
                        );
                    ;
                }
            }
            return listaNueva;
        }

        public async Task<string> CreateArbitro(Arbitro arbitro)
        {
            string sp_name = StoreProceduresNames.AB_SP_MANT;
            string transaccion = "CREAR_ARBITRO";
            string? mensaje = "";

            XDocument xmlData = DBXmlMethods.GetXml(arbitro);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());

            if (dataSet.Tables.Count > 0)
            {
                mensaje = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                return mensaje;
            }

            return mensaje;
        }

        public async Task<string> UpdateArbitro(Arbitro arbitro)
        {
            string sp_name = StoreProceduresNames.AB_SP_MANT;
            string transaccion = "ACTUALIZAR_ARBITRO";
            string? mensaje = "";

            XDocument xmlData = DBXmlMethods.GetXml(arbitro);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(sp_name, this.connectionString, transaccion, xmlData.ToString());
            if (dataSet.Tables.Count > 0)
            {
                mensaje = dataSet?.Tables[0]?.Rows[0]["ERROR"].ToString();
                return mensaje;
            }

            return mensaje;

        }

        public async Task<string> DeleteArbitro(Arbitro arbitro)
        {
            string sp_name = StoreProceduresNames.AB_SP_MANT;
            string transaccion = "ELIMINAR_ARBITRO";
            string? mensaje = "";

            XDocument xmlData = DBXmlMethods.GetXml(arbitro);
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

