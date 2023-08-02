using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.Excepciones;
using Modelos.repo;

namespace backend_project_netcore_faf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(IConfiguration configuration)
        {
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
            return Ok(user);
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
    }
}
