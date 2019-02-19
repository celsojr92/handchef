using HandChef.Domain.Commands.Inputs;
using HandChef.Domain.Handlers;
using HandChef.Domain.Repositories;
using HandChef.Shared.Commands;
using HandChef.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandChef.API.Controllers.v1
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeRepository _repository;
        private readonly RecipeHandler _handler;

        public RecipeController(IRecipeRepository repository, RecipeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [Route("api/v1/recipe/add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddRecipeCommand command)
        {
            try
            {
                var resultado = (GenericResult)await _handler.Handle(command);
                return await Response(resultado.Dados, null);
            }
            catch (Exception ex)
            {
                var notifications = new List<Notification>();
                notifications.Add(new Notification("Add Recipe", ex.Message));
                return await Response(null, notifications);
            }
        }
    }
}
