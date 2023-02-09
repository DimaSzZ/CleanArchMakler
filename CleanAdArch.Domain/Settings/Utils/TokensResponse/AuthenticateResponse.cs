namespace CleanAdArch.Domain.Settings.Utils.TokensResponse;

public record AuthenticateResponse(
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiresAt,
    DateTime RefreshTokenExpiresAt
    );