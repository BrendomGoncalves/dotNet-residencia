namespace MvcMovie.Data.Auth;

public interface IAuthService
{
    string GenerateJwtToken(string email, string role); 
    string ComputeSha256Hash(string pass);
}