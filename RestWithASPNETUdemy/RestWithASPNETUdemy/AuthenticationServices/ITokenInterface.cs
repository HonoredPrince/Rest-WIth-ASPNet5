﻿using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASPNETUdemy.AuthenticationServices
{
    public interface ITokenInterface
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
