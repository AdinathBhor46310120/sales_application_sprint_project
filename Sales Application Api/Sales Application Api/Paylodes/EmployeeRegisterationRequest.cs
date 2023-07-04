namespace Sales_Application_Api.Paylodes
{
    public class EmployeeRegisterationRequest
    {

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? Title { get; set; }

        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? HomePhone { get; set; }

        public string? Extension { get; set; }

        //public byte[]? Photo { get; set; }
        public IFormFile Photo { get; set; }

        public string? Notes { get; set; }

        public int? ReportsTo { get; set; }

        public string? PhotoPath { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
