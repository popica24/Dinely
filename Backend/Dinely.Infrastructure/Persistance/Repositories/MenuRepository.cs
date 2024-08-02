using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dinely.Application.Common.Interfaces.Persistance;
using Dinely.Domain.MenuAggregate;

namespace Dinely.Infrastructure.Persistance.Repositories
{
    public class MenuRepository(DinelyDbContext _dbContext) : IMenuRepository
    {
        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }

    }
}