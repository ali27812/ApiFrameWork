using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFramework.Api;

namespace ApiEntity.Controllers.v1
{
    
    [ApiVersion("1")]
    public class ValuesController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public virtual  ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "", "" };
        }
    }
}
