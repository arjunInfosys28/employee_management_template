using System;

namespace Core.Dtos
{
    public class EmployeeUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateHired { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
