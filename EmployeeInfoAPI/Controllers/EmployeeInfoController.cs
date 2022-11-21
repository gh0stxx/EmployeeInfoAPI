using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInfoController : ControllerBase
    {

        private readonly DataContext dataContext;

        public EmployeeInfoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeInfo>>> Get()
        {
            return Ok(await dataContext.Employees.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployeeInfo>>> Get(int id)
        {
            var employee = await dataContext.Employees.FindAsync(id);
            if (employee == null)
                return BadRequest("Employee Id not found");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<EmployeeInfo>>> AddEmployee(EmployeeInfo employee)
        {
            dataContext.Employees.Add(employee);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<EmployeeInfo>>> UpdateEmployee(EmployeeInfo toUpdate)
        {
            var employee = dataContext.Employees.Find(toUpdate.Id);
            if (employee == null)
                return BadRequest("Employee Id not found");

            employee.Name = toUpdate.Name;
            employee.Street = toUpdate.Street;
            employee.City = toUpdate.City;
            employee.Country = toUpdate.Country;
            employee.PhoneNumber = toUpdate.PhoneNumber;
            employee.Dept = toUpdate.Dept;
            employee.PostCode = toUpdate.PostCode;
            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.Employees.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EmployeeInfo>>> DeleteEmployee(int id)
        {
            var employee = dataContext.Employees.Find(id);
            if (employee == null)
                return BadRequest("Employee Id not found");

            dataContext.Employees.Remove(employee);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.Employees.ToListAsync());
        }
    }
}
