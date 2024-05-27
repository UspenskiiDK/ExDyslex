namespace Entities
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

        public User(int id, string firstName, string lastName, string? patronymicName, DateTime birthday, string password, int roleId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
            Birthday = birthday;
            Password = password;
            RoleId = roleId;
        }
    }
}
