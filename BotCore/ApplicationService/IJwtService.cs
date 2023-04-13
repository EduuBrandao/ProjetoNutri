using System;
using System.Collections.Generic;
using System.Text;

namespace BotCoreApplication.ApplicationService
{
    public interface IJwtService
    {
        string GenerateToken(Guid accountContextKey);
        bool ValidateToken(string token);
    }

}
