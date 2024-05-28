namespace DAL.DbModels
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? PatronymicName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? MainPhotoPath { get; set; }

        public Client(int id, string firstName, string lastName, string? patronymicName, 
            DateTime birthday, string? phone, string email, string password, string? mainPhotoPath)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
            Birthday = birthday;
            Phone = phone;
            Email = email;
            Password = password;
            MainPhotoPath = mainPhotoPath;
        }
    }
}
