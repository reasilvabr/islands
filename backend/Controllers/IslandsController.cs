using Application.Interface;
using Application.VO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslandsController : ControllerBase
    {
        private readonly IIslandsApp _app;

        public IslandsController(IIslandsApp app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<IActionResult> GetIslands([FromBody] int[][] world)
        {
            try
            {
                var lands = _app.GetLands(world);
                var result = _app.IdentifyIslands(lands);
                var ret = new List<int[][]>();
                result.ForEach(island => ret.Add(island.ToArray()));
                return Ok(ret.ToArray());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
