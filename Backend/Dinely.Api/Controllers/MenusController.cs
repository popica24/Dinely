using Dinely.Application.Menus.Commands.Menus;
using Dinely.Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Dinely.Api.Controllers
{
    [Route("api/hosts/{hostId}/menus")]
    public class MenusController(IMapper _mapper, ISender _sender) : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));

            var createCommandResult = await _sender.Send(command);

            return createCommandResult.Match(
                commandResult => Ok(_mapper.Map<MenuResponse>(commandResult)),
                errors => Problem(errors)
            );
        }
    }
}