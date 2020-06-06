using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers
{
  [Route("/")]
  public class HomeController : ControllerBase
  {
    private readonly ILogger _logger;

    private static string CurrentState = string.Empty;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public Resource Get()
    {
      return new Resource
      {
        State = CurrentState,
      };
    }

    [HttpPut]
    public IActionResult Put([FromBody] Resource resource)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _logger.LogInformation(
        EventIds.ResourceStateChanged,
        "Setting current state to '{state}'",
        resource.State);
      CurrentState = resource.State;

      return NoContent();
    }
  }
}
