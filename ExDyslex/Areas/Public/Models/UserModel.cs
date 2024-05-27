using Entities;

namespace ExDyslex.Areas.Public.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PatronymicName { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }

        public UserModel(int id, string firstName, string lastName, string? patronymicName, DateTime birthday, string password, int roleId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
            Birthday = birthday;
            Password = password;
            RoleId = roleId;
        }

        public UserModel? ConvertFromEntity(User userEntity)
        {
            return userEntity == null ? null :
                new UserModel(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.PatronymicName, userEntity.Birthday,
                    userEntity.Password, userEntity.RoleId);
        }

        public User? ConvertToEntity(UserModel userModel)
        {
            return userModel == null ? null :
                new User(userModel.Id, userModel.FirstName, userModel.LastName, userModel.PatronymicName, userModel.Birthday,
                    userModel.Password, userModel.RoleId);
        }
    }
}
