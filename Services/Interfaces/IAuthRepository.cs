using FastFiles.Dto;

namespace FastFiles.Services
{
    public interface IAuthRepository
    {
        string GenerateToken(Authorize user);
    }
}