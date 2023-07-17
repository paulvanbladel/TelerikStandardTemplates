using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikAdmin.Server.Data;
using TelerikAdmin.Shared.Models.Employee;

namespace TelerikAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataService _dataService;
        public EmployeeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public Task<List<Employee>> GetEmployees()
        {
            var result = _dataService.GetEmployees().ToList();
            return Task.FromResult(result);
        }
    }
}
