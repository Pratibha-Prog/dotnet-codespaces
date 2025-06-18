
namespace HttpVerbsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VerbsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("GET response");
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok("POST response");
    }

    [HttpPut]
    public IActionResult Put()
    {
        return Ok("PUT response");
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok("DELETE response");
    }

    [HttpPatch]
    public IActionResult Patch()
    {
        return Ok("PATCH response");
    }

    [HttpHead]
    public IActionResult Head()
    {
        return Ok(); // HEAD responses don’t return a body
    }

    [HttpOptions]
    public IActionResult Options()
    {
        Response.Headers.Add("Allow", "GET,POST,PUT,DELETE,PATCH,HEAD,OPTIONS");
        return Ok();
    }
}
