namespace Web.Scraping.Core.Dtos.Response;

public class RegisterResponseDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }    
}