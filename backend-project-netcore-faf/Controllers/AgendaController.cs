using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.repo;
using Modelos;

namespace backend_project_netcore_faf.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaRepository agendaRepository;

        public AgendaController(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            agendaRepository = new AgendaRepository(connection);
        }

        /* Obtener Agendas */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [Route("[action]")]
        public async Task<ActionResult<List<Agenda>>> GetAgendasPartidos(string? transaction = null, string? filtro = "")
        {
            List<Agenda> lista = await agendaRepository.ListarAgendasPartidos(transaction!, filtro!);
            if (lista == null)
            {
                return NotFound("No hay Agendas disponibles");
            }
            return lista;
        }

        /* Crear */
        [Authorize]
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Respuesta>> SaveAgenda(Agenda agenda)
        {
            //Console.WriteLine(actaPartido.ToString());

            return await agendaRepository.MantAgendaPartido(agenda, "CREAR_AGENDA_PARTIDO");
        }

        /*[Route("[action]")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Respuesta>> UpdateActaPartido(Agenda agenda)
        {
            return await agendaRepository.MantAgendaPartido(agenda, "");
        }*/

        [Authorize]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<ActionResult<Respuesta>> DeleteAgenda(int id)
        {
            Agenda agenda = new Agenda { Id = id };

            return await agendaRepository.MantAgendaPartido(agenda, "ELIMINAR_AGENDA_PARTIDO");
        }

    }
}
