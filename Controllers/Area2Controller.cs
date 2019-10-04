using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace AreaCalculatorRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class Area2Controller : ControllerBase
    {
        // GET: api/Area2
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Area2/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Area2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Area2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
