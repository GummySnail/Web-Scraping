namespace Web.Scraping.Core.Dtos.Response;

public class LoginResponseDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
    public string Refreshtoken { get; set; }
}