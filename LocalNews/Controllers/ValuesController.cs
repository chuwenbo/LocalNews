using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalNews.Service;
using Microsoft.AspNetCore.Mvc;

namespace LocalNews.Controllers
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly LocalNewsDBContext _context;

        public ValuesController(LocalNewsDBContext context)
        {
            this._context = context; 
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var news = _context.LocalNews_Main.Where(p => true).ToList();  

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
