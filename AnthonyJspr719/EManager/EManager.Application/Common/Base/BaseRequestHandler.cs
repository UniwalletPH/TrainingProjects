using EManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EManager.Application.Common.Base
{
    public class BaseRequestHandler
    {
        internal readonly IEManagerDbContext dbContext;

        public BaseRequestHandler(IEManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
