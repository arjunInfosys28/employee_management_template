using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Task AddAsync(Employee employee)
        {
            // TODO: Add business validation, mapping, events, etc.
            return _repo.AddAsync(employee);
        }

        public Task DeleteAsync(Guid id)
        {
            // TODO: Add authorization or business rules
            return _repo.DeleteAsync(id);
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<Employee?> GetByIdAsync(Guid id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task UpdateAsync(Employee employee)
        {
            // TODO: Add validation and conflict handling
            return _repo.UpdateAsync(employee);
        }
    }
}
