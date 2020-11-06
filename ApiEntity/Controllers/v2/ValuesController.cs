using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiEntity.Controllers.v2
{
    [ApiVersion("2")]
    public class ValuesController : v1.ValuesController
    {
        public override ActionResult<IEnumerable<string>> Get()
        {
            return base.Get();
        }
    }
}
