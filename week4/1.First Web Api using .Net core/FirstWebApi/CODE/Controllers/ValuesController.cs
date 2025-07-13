using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // Static list to store values in memory
        private static List<string> values = new List<string>
        {
            "Name: SAUMY RAJ",
            "Superset ID: 6363348",
            "College: KIIT"
        };

        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return values;
        }

        
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("ID not found");
            return values[id];
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return Ok($"Added: {value}");
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("ID not found");

            values[id] = value;
            return Ok($"Updated id {id} with value {value}");
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("ID not found");

            values.RemoveAt(id);
            return Ok($"Deleted id {id}");
        }
    }
}
