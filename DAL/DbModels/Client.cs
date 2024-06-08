namespace DAL.DbModels
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? PatronymicName { get; set; }
        public string Birthday { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? MainPhotoPath { get; set; }
        public virtual ICollection<TestsToClient> TestsToClients { get; set; }
    }
}
