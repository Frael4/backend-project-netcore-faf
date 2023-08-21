using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos.repo;
using Modelos;

namespace backend_project_netcore_faf.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly EquipoRepository equipoRepository;

        public EquipoController(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            equipoRepository = new EquipoRepository(connection);
        }

        /* Obtener Agendas */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        [Route("[action]")]
        public async Task<ActionResult<List<Equipo>>> GetEquipos(string? transaction = null, string? filtro = "")
        {
            List<Equipo> lista = await equipoRepository.GetEquipos(transaction!, filtro!);
            if (lista == null)
            {
                return NotFound("No hay equipos disponibles");
            }
            return lista;
        }

        /* Crear */
        [Authorize]
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Respuesta>> SaveEquipo(Equipo equipo)
        {
            //Console.WriteLine(actaPartido.ToString());

            return await equipoRepository.MantEquipo(equipo, "CREAR_EQUIPO");
        }

        [Authorize]
        [Route("[action]")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Respuesta>> UpdateEquipo(Equipo equipo)
        {
            return await equipoRepository.MantEquipo(equipo, "ACTUALIZAR_EQUIPO");
        }

        [Authorize]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<ActionResult<Respuesta>> DeleteEquipo(int id)
        {
            Equipo equipo = new Equipo { Id = id };

            return await equipoRepository.MantEquipo(equipo, "ELIMINAR_EQUIPO");
        }
    }
}
