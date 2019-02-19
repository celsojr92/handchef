using HandChef.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandChef.API.Controllers.v1
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Response(object result, IReadOnlyCollection<Notification> erros)
        {
            if (erros != null && erros.Any())
                return BadRequest(new ResponseBase(false, null, erros));

            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(new ResponseBase(true, result));
            }
        }

        public class ResponseBase
        {
            public bool Sucesso { get; private set; }
            public object Dados { get; private set; }
            public IReadOnlyCollection<Notification> Erros { get; private set; }

            public ResponseBase(bool sucesso, object dados, IReadOnlyCollection<Notification> erros = null)
            {
                Dados = dados;
                Sucesso = sucesso;
                this.Erros = erros;
            }
        }
    }
}
