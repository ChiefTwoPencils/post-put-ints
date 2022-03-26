using Microsoft.AspNetCore.Mvc;

namespace PutPosts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Ints : ControllerBase
    {
        public IActionResult Get() => new JsonResult("it works");

        [HttpPost]
        public IActionResult Post(List<List<int>> ints) => new JsonResult(
            $"a [{ints.Count},{ints[0].Count}] was received and deserialized as List<List<int>>.");

        [HttpPut]
        public IActionResult Put(int [,] ints) => new JsonResult(
            $"a [{ints.GetLength(0)},{ints.GetLength(1)}] was received and deserialized as int[,].");
    }
}
