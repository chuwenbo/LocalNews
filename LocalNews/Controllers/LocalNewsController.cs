using LocalNews.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalNewsController : ControllerBase
    {  
        private readonly LocalNewsDBContext _context;

        public LocalNewsController(LocalNewsDBContext context)
        {
            this._context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
