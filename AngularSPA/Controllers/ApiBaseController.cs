using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularSPA.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : Controller
    {
    }
}