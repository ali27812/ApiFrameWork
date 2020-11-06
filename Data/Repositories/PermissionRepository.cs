using Common;
using Data.Contracts;
using Entites;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository, IScopedDependency
    {
        private readonly ILogger<PermissionRepository> _log;
        //seriLog
        public PermissionRepository(ApplicationDbContext dbContext, ILogger<PermissionRepository> logger)
            : base(dbContext)
        {
            _log = logger;
        }

    }
}
