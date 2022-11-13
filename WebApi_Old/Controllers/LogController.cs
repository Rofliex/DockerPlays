using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {

        private readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string MakeLog([FromQuery] string text)
        {
            var formatedLog = $"{DateTime.UtcNow:G} - {text}";
            _logger.LogInformation(formatedLog);
            return formatedLog;
        }

       
    }
}