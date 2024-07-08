using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWebAPI.Data;
using RepositoryPatternWebAPI.Models;
using RepositoryPatternWebAPI.Services.EmployeeListService;

namespace RepositoryPatternWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeListsController : ControllerBase
    {
        private readonly RepositoryPatternWebAPIContext _context;
        private readonly IEmployeeListService _EmployeeListService;

        public EmployeeListsController(RepositoryPatternWebAPIContext context, IEmployeeListService EmployeeListService)
        {
            _context = context;
            _EmployeeListService = EmployeeListService;
        }

        // GET: api/EmployeeLists
        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            //return _EmployeeListService.GetEmployeeList();

            var a= await _context.EmployeeList.ToListAsync();

            return Ok(a);
        }

        // GET: api/EmployeeLists/5
        [HttpGet("{id}")]
        public Task<ActionResult<EmployeeList>> GetEmployeeList(int id)
        {
            return _EmployeeListService.GetEmployeeList(id);
        }

        // PUT: api/EmployeeLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Task<IActionResult> PutEmployeeList(int id, EmployeeList employeeList)
        {
            return _EmployeeListService.PutEmployeeList(id, employeeList);
        }

        // POST: api/EmployeeLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Task<ActionResult<EmployeeList>> PostEmployeeList(EmployeeList employeeList)
        {
            return _EmployeeListService.PostEmployeeList(employeeList);
        }

        // DELETE: api/EmployeeLists/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteEmployeeList(int id)
        {
            return _EmployeeListService.DeleteEmployeeList(id);
        }

        private bool EmployeeListExists(int id)
        {
            return _context.EmployeeList.Any(e => e.EmpId == id);
        }
    }
}
