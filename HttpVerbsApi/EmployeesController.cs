

namespace EmployeeApi.Controllers;

[ApiController]
[Route("employees")]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeesController(EmployeeService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int size = 10)
        => Ok(_service.GetAll(page, size));

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var emp = _service.Get(id);
        return emp == null ? NotFound() : Ok(emp);
    }

    [HttpPost]
    public IActionResult Create(Employee emp)
    {
        var created = _service.Create(emp);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee emp)
    {
        return _service.Update(id, emp) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _service.Delete(id) ? NoContent() : NotFound();
    }
}
