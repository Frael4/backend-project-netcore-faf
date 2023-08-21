using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.Excepciones;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Modelos.repo;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace backend_project_netcore_faf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            string connection = configuration.GetConnectionString("DefaultConnection");
            userRepository = new UserRepository(connection);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> Login(User usuario)
        {
            User user;
            user =  await userRepository.Login(usuario);
            if( user == null){
                return NotFound("Usuario no encontrado");
            }

            return Ok(JsonConvert.SerializeObject(CreateToken(user)));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<Respuesta>> Register(User usuario)
        {
            //User user = new User();
            Respuesta? user;
            try
            {
                user = await userRepository.Register(usuario);
                return Ok(user);
            }
            catch(UserException ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound("Ocurrio un error");
            }

        }

        private string CreateToken(User usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombres!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); /**/

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = creds,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            /* Devolvemos el token */
            return tokenHandler.WriteToken(token);
        }
    }

}

