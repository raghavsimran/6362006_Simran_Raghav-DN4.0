using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiJsonWebToken.Models;

namespace ApiJsonWebToken.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")] // Role-based access
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Department = new Department { Id = 101, DeptName = "HR" },
                Skills = new List<Skill> { new Skill { SkillName = "Excel" } }
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Department = new Department { Id = 102, DeptName = "IT" },
                Skills = new List<Skill> { new Skill { SkillName = "C#" } }
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return Ok(_employees);
        }
    }
}
