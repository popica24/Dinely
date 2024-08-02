using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dinely.Domain.MenuAggregate.Events;

using MediatR;

namespace Dinely.Application.Menus.Events
{
    public class DummyEventHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}