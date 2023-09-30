using System;

namespace BotCoreApplication.ApplicationService
{
    public interface IJwtService
    {
        string GenerateToken(Guid accountContextKey);
        bool ValidateToken(string token);
    }

}
