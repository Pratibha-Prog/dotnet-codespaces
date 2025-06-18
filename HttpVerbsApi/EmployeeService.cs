
public class EmployeeService
{
    private readonly List<Models> _employees = new();
    private int _nextId = 1;

    public EmployeeService()
    {
        _employees.Add(new Employee { Id = _nextId++, FullName = "John Doe", Department = "HR", Email = "john@example.com" });
        _employees.Add(new Employee { Id = _nextId++, FullName = "Jane Smith", Department = "Finance", Email = "jane@example.com" });
    }

    public IEnumerable<Models> GetAll(int page = 1, int size = 10) =>
        _employees.Skip((page - 1) * size).Take(size);

    public Employee? Get(int id) => _employees.FirstOrDefault(e => e.Id == id);

    public Employee Create(Employee emp)
    {
        emp.Id = _nextId++;
        _employees.Add(emp);
        return emp;
    }

    public bool Update(int id, Employee emp)
    {
        var existing = Get(id);
        if (existing == null) return false;

        existing.FullName = emp.FullName;
        existing.Department = emp.Department;
        existing.Email = emp.Email;
        return true;
    }

    public bool Delete(int id)
    {
        var emp = Get(id);
        return emp != null && _employees.Remove(emp);
    }
}
