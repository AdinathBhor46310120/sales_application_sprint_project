namespace Sales_Application_Api.Paylodes
{
    public class AdminRegisterRequest
    {
        public int AdminId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
