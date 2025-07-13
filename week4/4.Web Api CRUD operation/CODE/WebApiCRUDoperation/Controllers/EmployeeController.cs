using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> _employees = new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "John Doe",
            Department = new Department { Id = 101, DeptName = "HR" },
            Skills = new List<Skill> { new Skill { SkillName = "Communication" } }
        },
        new Employee
        {
            Id = 2,
            Name = "Jane Smith",
            Department = new Department { Id = 102, DeptName = "IT" },
            Skills = new List<Skill> { new Skill { SkillName = "C#" } }
        },
        new Employee
        {
            Id = 3,
            Name = "Bob Johnson",
            Department = new Department { Id = 103, DeptName = "Finance" },
            Skills = new List<Skill> { new Skill { SkillName = "Excel" } }
        }
    };

    // GET: api/Employee
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Employee>> GetAllEmployees()
    {
        return Ok(_employees);
    }

    // GET: api/Employee/2
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public ActionResult<Employee> GetEmployeeById(int id)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == id);
        if (emp == null)
        {
            return NotFound($"Employee with id {id} not found");
        }

        return Ok(emp);
    }

    // POST: api/Employee
    [HttpPost]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> AddEmployee([FromBody] Employee newEmployee)
    {
        if (newEmployee == null || newEmployee.Id <= 0)
        {
            return BadRequest("Invalid employee data");
        }

        if (_employees.Any(e => e.Id == newEmployee.Id))
        {
            return BadRequest("Employee with the same ID already exists");
        }

        _employees.Add(newEmployee);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
    }

    // PUT: api/Employee/2
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        existingEmployee.Name = updatedEmployee.Name;
        existingEmployee.Department = updatedEmployee.Department;
        existingEmployee.Skills = updatedEmployee.Skills;

        return Ok(existingEmployee);
    }

    // DELETE: api/Employee/3
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult DeleteEmployee(int id)
    {
        var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
        if (employeeToRemove == null)
        {
            return NotFound("Employee not found");
        }

        _employees.Remove(employeeToRemove);
        return NoContent(); // 204
    }
}
