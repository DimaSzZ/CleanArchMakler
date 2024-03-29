﻿using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.RefreshToken;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class RefreshTokenRepository: IRefreshTokenRepository
{
    private readonly SupabaseDbContext _ctx;

    public RefreshTokenRepository(SupabaseDbContext ctx)
    {
        _ctx = ctx;
    }
    public async Task Save(RefreshToken token, CancellationToken cancellationToken)
    {
        if (_ctx.RefreshTokens.Contains(token))
            _ctx.RefreshTokens.Update(token);
        else
            await _ctx.RefreshTokens.AddAsync(token, cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<RefreshToken?> OneByToken(string token, CancellationToken cancellationToken)
    {
        return await _ctx.RefreshTokens
            .FirstOrDefaultAsync(refreshToken => refreshToken.Token == token,
                cancellationToken);
    }
}