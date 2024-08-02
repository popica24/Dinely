using Dinely.Application.Common.Interfaces.Persistance;
using Dinely.Domain.HostAggregate.ValueObjects;
using Dinely.Domain.MenuAggregate;
using Dinely.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace Dinely.Application.Menus.Commands.Menus
{
    public class CreateMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = Menu.Create(
                hostId: HostId.Create(request.HostId),
                name: request.Name,
                description: request.Description,
                sections: request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(
                      item.Name,
                      item.Description
                  ))
                  ))
            );

            _menuRepository.Add(menu);

            return menu;
        }

    }
}
