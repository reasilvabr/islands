using Application;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private readonly IAsteroidsApp _app;

        public AsteroidsController(IAsteroidsApp app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomSimulationData([FromQuery] int size = 5)
        {
            try
            {
                return Ok(_app.GetRandomData(size));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SimulateAsteroid([FromBody] int[] asteroids)
        {
            try
            {
                return Ok(_app.AsteroidsSimulator(asteroids));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
