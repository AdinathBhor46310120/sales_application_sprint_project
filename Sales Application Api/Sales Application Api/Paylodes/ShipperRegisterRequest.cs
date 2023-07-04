namespace Sales_Application_Api.Paylodes
{
    public class ShipperRegisterRequest
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? Phone { get; set; }
    }
}
