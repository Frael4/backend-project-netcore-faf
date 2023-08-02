using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class User
    {
        private int idUsuario;

        private string? usuario;

        private string? nombres;

        private string? apellidos;

        private string? contrasenia;

        public User () { }
        public User(int idUsuario, string usuario, string nombres, string apellidos, string contrasenia)
        {
            this.idUsuario = idUsuario;
            this.usuario = usuario;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.contrasenia = contrasenia;
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string? Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        // (string?) -> Indica campo opcional
        public string? Nombres
        {
            get { return nombres; }
            set { nombres = value; }    
        }

        public string? Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
            }
        }

        public string? Contrasenia
        {
            get { return contrasenia;}
            set
            {
                contrasenia = value;
            }
        }
    }
}
