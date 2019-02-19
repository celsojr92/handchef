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
    public class UserController : BaseController
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;

        public UserController(IUserRepository repository, UserHandler handler) 
        {
            _repository = repository;
            _handler = handler;
        }

        [Route("api/v1/user/add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddUserCommand command)
        {
            try
            {
                var resultado = (GenericResult)await _handler.Handle(command);
                return await Response(resultado.Dados, null);
            }
            catch (Exception ex)
            {
                var notifications = new List<Notification>();
                notifications.Add(new Notification("Add User", ex.Message));
                return await Response(null, notifications);
            }
        }

        [Route("api/v1/user/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]EditUserCommand command)
        {
            try
            {
                var resultado = (GenericResult)await _handler.Handle(command);
                return await Response(resultado.Dados, null);
            }
            catch (Exception ex)
            {
                var notifications = new List<Notification>();
                notifications.Add(new Notification("Edit User", ex.Message));
                return await Response(null, notifications);
            }
        }
    }
}
