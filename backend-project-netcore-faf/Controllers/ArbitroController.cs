using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.repo;

namespace backend_project_netcore_faf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArbitroController : Controller
    {
        private readonly ArbitroRepository arbitroRepository;

        public ArbitroController(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection1");
            arbitroRepository = new ArbitroRepository(connection);
        }

        [HttpGet(Name = "GetArbitro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Arbitro> GetArbitro()
        {
            return arbitroRepository.ListarArbitro().Result;
        }

        [HttpPost(Name = "PostArbitro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<string>> SaveArbitro(Arbitro arbitro)
        {
           

            return await arbitroRepository.CreateArbitro(arbitro);
        }

        [HttpPut(Name = "UpdateArbitro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> UpdateArbitro(Arbitro arbitro)
        {
            return await arbitroRepository.UpdateArbitro(arbitro);
        }

        [HttpDelete(Name = "DeleteArbitro/{id}")]
        public async Task<ActionResult<string>> DeleteArbitro(int id)
        {
            Arbitro arbitro = new Arbitro { Id = id };

            return await arbitroRepository.DeleteArbitro(arbitro);
        }
    }










}

