using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWebAPI.Data;
using RepositoryPatternWebAPI.Models;

namespace RepositoryPatternWebAPI.Services.EmployeeListService
{
    public class EmployeeListService: ControllerBase, IEmployeeListService
    {
        private readonly RepositoryPatternWebAPIContext _context;

        public EmployeeListService(RepositoryPatternWebAPIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<EmployeeList>>> GetEmployeeList()
        {
            return await _context.EmployeeList.ToListAsync();
        }

        public async Task<ActionResult<EmployeeList>> GetEmployeeList(int id)
        {
            var employeeList = await _context.EmployeeList.FindAsync(id);

            if (employeeList == null)
            {
                return NotFound("Wrong ID");
            }

            return employeeList;
        }

        public async Task<IActionResult> PutEmployeeList(int id, EmployeeList employeeList)
        {
            if (id != employeeList.EmpId)
            {
                return BadRequest("Bad request");
            }

            _context.Entry(employeeList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeListExists(id))
                {
                    return NotFound("This ID does not available");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Data edited successfully for id: "+id);
        }

        public async Task<ActionResult<EmployeeList>> PostEmployeeList(EmployeeList employeeList)
        {
            _context.EmployeeList.Add(employeeList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeList", new { id = employeeList.EmpId }, employeeList);
        }

        public async Task<IActionResult> DeleteEmployeeList(int id)
        {
            var employeeList = await _context.EmployeeList.FindAsync(id);
            if (employeeList == null)
            {
                return NotFound("This ID does not available");
            }

            _context.EmployeeList.Remove(employeeList);
            await _context.SaveChangesAsync();

            return Ok("Data deleted successfully for id: " + id);
        }

        private bool EmployeeListExists(int id)
        {
            return _context.EmployeeList.Any(e => e.EmpId == id);
        }
    }
}