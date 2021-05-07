using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serviceA.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace serviceA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        private readonly IApplication _application;
        public MainController(ILogger<MainController> logger, IApplication application)
        {
            _logger = logger;
            _application = application;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Service A Get endpoint");

            try
            {
                var appResponse = "testing...";

                return Ok($"Service A Ok... {appResponse}::!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("serviceB")]
        public async Task<IActionResult> GetServiceB()
        {
            _logger.LogInformation("Service A Get endpoint");

            try
            {
                var appResponse = await _application.GetResponse();

                return Ok($"Service A Ok... {appResponse} ::\nService B contacted successfully!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
