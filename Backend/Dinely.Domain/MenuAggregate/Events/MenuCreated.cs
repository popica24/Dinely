using Dinely.Domain.Common.Models;

namespace Dinely.Domain.MenuAggregate.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;
