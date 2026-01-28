using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiEntity.Models;
using Data.Contracts;
using Data.Repositories;
using Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Services;
using WebFramework.Api;

namespace ApiEntity.Controllers.v2
{
    [ApiVersion("2")]
    public class UserController : v1.UserController
    {
        public UserController(IUnitOfWork iunitOfWork,IUserRepository userRepository, IJwtService jwtService, ILogger<UserController> logger) : base(iunitOfWork,userRepository, jwtService,logger)
        {
        }      
        public override Task<ApiResult<User>> Create(UserDto userDto, CancellationToken cancellationToken)
        {
            return base.Create(userDto, cancellationToken);
        }

        public override Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            return base.Delete(id, cancellationToken);
        }

        public override Task<ActionResult<List<User>>> Get(CancellationToken cancellationToken)
        {
            return base.Get(cancellationToken);
        }

        public override Task<ApiResult<User>> Get(int id, CancellationToken cancellationToken)
        {
            return base.Get(id, cancellationToken);
        }

        public override Task<ActionResult<string>> Token([FromForm] TokenModel tokenModel, CancellationToken cancellationToken)
        {
            return base.Token(tokenModel, cancellationToken);
        }

        public override Task<ApiResult> Update(int id, UserDto user, CancellationToken cancellationToken)
        {
            return base.Update(id, user, cancellationToken);
        }
    }
}
