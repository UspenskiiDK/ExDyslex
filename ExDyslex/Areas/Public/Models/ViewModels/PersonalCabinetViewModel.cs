using Entities;
using System.ComponentModel.DataAnnotations;

namespace ExDyslex.Areas.Public.Models
{
    public class PersonalCabinetViewModel
    {
        public ClientModel ClinetModel { get; set; }
        public string OldPassword { get; set; }

    }
}
