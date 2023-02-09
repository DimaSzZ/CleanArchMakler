using CleanAdArch.Domain.Models.RefreshToken;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface IRefreshTokenRepository
{
    public Task Save(RefreshToken token, CancellationToken cancellationToken);
    public Task<RefreshToken?> OneByToken(string token, CancellationToken cancellationToken);
}