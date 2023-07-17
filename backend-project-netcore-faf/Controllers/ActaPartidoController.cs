using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.repo;

namespace backend_project_netcore_faf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActaPartidoController: ControllerBase
    {
        private readonly ActaPartidoRepository actaPartidoRepository;

        public ActaPartidoController(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            actaPartidoRepository = new ActaPartidoRepository(connection);
        }
        
        /* Obtener actas */
        [HttpGet(Name = "GetActaPartidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ActaPartido> GetActasPartido()
        {
            return actaPartidoRepository.ListarActasPartido().Result;
        }

        /* Crear */
        [HttpPost(Name = "PostActaPartido")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<string>> SaveActaPartido(ActaPartido actaPartido)
        {
            //Console.WriteLine(actaPartido.ToString());

            return await actaPartidoRepository.CreateActaPartido(actaPartido);
        }

        [HttpPut(Name = "UpdateActaPartido" )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> UpdateActaPartido(ActaPartido actaPartido)
        {
            return await actaPartidoRepository.UpdateActaPartido(actaPartido);
        }

        [HttpDelete(Name = "DeleteActaPartido/{id}")]
        public async Task<ActionResult<string>> DeleteActaPartido(int id)
        {
            ActaPartido actaPartido = new ActaPartido { Id = id };

            return await actaPartidoRepository.DeleteActaPartido(actaPartido);
        }
    }
}
