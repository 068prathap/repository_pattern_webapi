using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWebAPI.Models;

namespace RepositoryPatternWebAPI.Data
{
    public class RepositoryPatternWebAPIContext : DbContext
    {
        public RepositoryPatternWebAPIContext (DbContextOptions<RepositoryPatternWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RepositoryPatternWebAPI.Models.EmployeeList> EmployeeList { get; set; } = default!;
    }
}