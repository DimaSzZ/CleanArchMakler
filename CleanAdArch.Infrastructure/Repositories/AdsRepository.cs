using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.Ads;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class AdsRepository : IAdsRepository
{
    private readonly SupabaseDbContext _ctx;

    public AdsRepository(
        SupabaseDbContext ctx
    )
    {
        _ctx = ctx;
    }

    public async Task Save(Ads ads, CancellationToken cancellationToken)
    {
        if (_ctx.AdsEnumerable.Contains(ads))
        {
            _ctx.Update(ads);
        }
        else
            await _ctx.AdsEnumerable.AddAsync(ads, cancellationToken);

        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<Ads?> OnById(Guid id, CancellationToken cancellationToken)
    {
      return await _ctx.AdsEnumerable
          .Where(ads => ads.Id == id)
          .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Delete(Ads ads, CancellationToken cancellationToken)
    {
        _ctx.AdsEnumerable.Remove(ads);
        await _ctx.SaveChangesAsync(cancellationToken);
    }
}