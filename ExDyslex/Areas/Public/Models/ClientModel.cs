using Entities;

namespace ExDyslex.Areas.Public.Models
{
    public class ClientModel
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

        public ClientModel(int id, string firstName, string? lastName, string? patronymicName, 
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

        public ClientModel? ConvertFromEntity(Client clientEntity)
        {
            return clientEntity == null ? null :
                new ClientModel(clientEntity.Id,clientEntity.FirstName, clientEntity.LastName, clientEntity.PatronymicName,
                    clientEntity.Birthday, clientEntity.Phone, clientEntity.Email, clientEntity.Password, clientEntity.MainPhotoPath);
        }

        public Client? ConvertToEntity(ClientModel clientModel)
        {
            return clientModel == null ? null :
                new Client(clientModel.Id, clientModel.FirstName, clientModel.LastName, clientModel.PatronymicName,
                    clientModel.Birthday, clientModel.Phone, clientModel.Email, clientModel.Password, clientModel.MainPhotoPath);
        }
    }
}
