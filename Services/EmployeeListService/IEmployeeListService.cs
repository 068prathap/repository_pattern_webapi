using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWebAPI.Models;

namespace RepositoryPatternWebAPI.Services.EmployeeListService
{
    public interface IEmployeeListService
    {
        Task<ActionResult<IEnumerable<EmployeeList>>> GetEmployeeList();

        Task<ActionResult<EmployeeList>> GetEmployeeList(int id);

        Task<IActionResult> PutEmployeeList(int id, EmployeeList employeeList);

        Task<ActionResult<EmployeeList>> PostEmployeeList(EmployeeList employeeList);

        Task<IActionResult> DeleteEmployeeList(int id);
    }
}