using System.Threading.Tasks;
using Camada.Domain.Interfaces;
using Camada.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Camada.Aplicacao.Controllers
{
    [Route("api/TodoItem/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ServiceBase servicos;

        public BaseController(ServiceBase servicos)
        {
            this.servicos = servicos;
        }

        [HttpPost]
        [Route("inserirItem")]
        public IActionResult InserirItem ([FromBody] int id, string nome, string estaCompleto)
        {
            var resultado = servicos.ExecutarInsert(new RItemEntidade()
            {
                Id = id,
                Nome = nome,
                EstaCompleto = estaCompleto
            });

            return new ObjectResult(resultado);
        }

        [HttpPut]
        [Route("atualizarItem")]
        public IActionResult atualizarItem([FromBody] int id, string nome, string estaCompleto)
        {
            var resultado = servicos.ExecutarUpdate(new RItemEntidade()
            {
                Id = id,
                Nome = nome,
                EstaCompleto = estaCompleto
            });

            return new ObjectResult(resultado);
        }

        [HttpPut]
        [Route("deletarItem")]
        public IActionResult deletarItem([FromBody] int id)
        {
            var resultado = servicos.ExecutarRemove(id); 
            return new ObjectResult(resultado);
        }

        [HttpGet]
        [Route("selecionarItem")]
        public IActionResult selecionarItem([FromBody] int id)
        {
            var resultado = servicos.ExecutarSelect(id);
            return new ObjectResult(resultado);
        }
    }
}