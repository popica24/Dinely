using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dinely.Domain.MenuAggregate;

namespace Dinely.Application.Common.Interfaces.Persistance
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}