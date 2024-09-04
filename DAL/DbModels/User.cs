namespace DAL.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PatronymicName { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
