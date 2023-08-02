using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.repo;

namespace backend_project_netcore_faf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActaPartidoController : ControllerBase
    {
        private readonly ActaPartidoRepository actaPartidoRepository;

        public ActaPartidoController(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            actaPartidoRepository = new ActaPartidoRepository(connection);
        }

        /* Obtener actas */
        [HttpGet(Name = "GetActaPartidos/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ActaPartido>>> GetActasPartido(string? transaction = null, string? filtro = "")
        {
            List<ActaPartido> lista = await actaPartidoRepository.ListarActasPartido(transaction, filtro);
            if (lista == null)
            {
                return NotFound("No hay actas disponibles");
            }
            return lista;
        }

        /* Crear */
        [HttpPost(Name = "PostActaPartido")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Respuesta>> SaveActaPartido(ActaPartido actaPartido)
        {
            //Console.WriteLine(actaPartido.ToString());

            return await actaPartidoRepository.CreateActaPartido(actaPartido);
        }

        [HttpPut(Name = "UpdateActaPartido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Respuesta>> UpdateActaPartido(ActaPartido actaPartido)
        {
            return await actaPartidoRepository.UpdateActaPartido(actaPartido);
        }

        [HttpDelete(Name = "DeleteActaPartido/{id}")]
        public async Task<ActionResult<Respuesta>> DeleteActaPartido(int id)
        {
            ActaPartido actaPartido = new ActaPartido { Id = id };

            return await actaPartidoRepository.DeleteActaPartido(actaPartido);
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ActaPartido>> GetActaPartido(int id)
        {

            ActaPartido? actaPartido = new ActaPartido() { Id = id };

            actaPartido = await actaPartidoRepository.GetActaPartido(actaPartido);

            if (actaPartido == null)
            {
                return NotFound("No se encontra acta con id nulo");
            }
            return actaPartido;
        }
    }
}
