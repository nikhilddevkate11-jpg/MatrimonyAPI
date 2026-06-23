using Matrimony.Models.Entities;

namespace Matrimony.API.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Email { get; set; } = "";

    public string PasswordHash { get; set; } = "";

    public string Mobile { get; set; } = "";
}