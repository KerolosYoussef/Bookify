namespace Bookify.Dtos;

public class UserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public IEnumerable<string> Roles { get; set; }
}