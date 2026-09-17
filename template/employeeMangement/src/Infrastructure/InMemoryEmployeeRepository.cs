using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public InMemoryEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    Position = "Software Engineer",
                    DateOfBirth = new DateTime(1990, 5, 24),
                    DateHired = DateTime.UtcNow.AddYears(-3),
                    Salary = 90000m,
                    IsActive = true
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bob.smith@example.com",
                    Position = "QA Engineer",
                    DateOfBirth = new DateTime(1987, 11, 2),
                    DateHired = DateTime.UtcNow.AddYears(-1),
                    Salary = 70000m,
                    IsActive = true
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Carol",
                    LastName = "Williams",
                    Email = "carol.williams@example.com",
                    Position = "Product Manager",
                    DateOfBirth = new DateTime(1985, 3, 14),
                    DateHired = DateTime.UtcNow.AddYears(-5),
                    Salary = 110000m,
                    IsActive = true
                }
            };
        }

        public Task AddAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing != null) _employees.Remove(existing);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            // Return a snapshot to avoid external mutation
            return Task.FromResult<IEnumerable<Employee>>(_employees.ToList());
        }

        public Task<Employee?> GetByIdAsync(Guid id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }

        public Task UpdateAsync(Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.FirstName = employee.FirstName;
                existing.LastName = employee.LastName;
                existing.Email = employee.Email;
                existing.Position = employee.Position;
                existing.DateOfBirth = employee.DateOfBirth;
                existing.DateHired = employee.DateHired;
                existing.Salary = employee.Salary;
                existing.IsActive = employee.IsActive;
            }

            return Task.CompletedTask;
        }
    }
}
