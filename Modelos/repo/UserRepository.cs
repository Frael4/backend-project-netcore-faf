using Modelos.Excepciones;
using Modelos.Shared;
using System.Data;
using System.Xml.Linq;

namespace Modelos.repo
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connection)
        {
            this.connectionString = connection;
        }
        public async Task<User> Login(User usuario)
        {
            User? user = null; // instanciado en null
            XDocument xmlData = DBXmlMethods.GetXml(usuario);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(StoreProceduresNames.USER_SP_CONS, this.connectionString, "INICIAR_SESION", xmlData.ToString());
            
            Console.WriteLine(dataSet.Tables[0].Rows.Count);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                using (DataTable table = dataSet.Tables[0])
                {
                    user = new User()
                    {
                        Nombres = (table.Rows[0]["nombre"].ToString()),
                        Apellidos = (table.Rows[0]["apellido"].ToString()),
                        Usuario = (table.Rows[0]["nombre_usuario"].ToString()),
                        Contrasenia = (table.Rows[0]["contrasenia"].ToString())
                    };
                }
            }
            else
            {
                Console.WriteLine("USuario no encontrado!");
                //throw new UserException("Usuario no encontrado");
            }


            return (user);
        }
        

        public async Task<Respuesta> Register(User usuario)
        {
            Respuesta? res = new();

            XDocument xmlData = DBXmlMethods.GetXml(usuario);
            DataSet dataSet = await DBXmlMethods.EjecutaBase(StoreProceduresNames.USER_SP_MANT, this.connectionString, "REGISTRAR_USUARIO", xmlData.ToString());

            using (DataTable table = dataSet.Tables[0])
            {
                if (table.Rows.Count > 0)
                {
                    res.Response = table.Rows[0]["RESPONSE"]?.ToString();
                    res.Error = table.Rows[0]["ERROR"].ToString();
                }
                
            }

                return res;
        }
    }
}
