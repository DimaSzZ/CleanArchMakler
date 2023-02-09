using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.EndpointLog;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;

namespace CleanAdArch.Infrastructure.Repositories;

public class EndpointLogRepository : IEndpointLogRepository
{
    private readonly SupabaseDbContext _ctx;

    public EndpointLogRepository(SupabaseDbContext ctx)
    {
        _ctx = ctx;
    }
    public async Task Save(EndpointLog log)
    {
        await _ctx.EndpointLogs.AddAsync(log);
        await _ctx.SaveChangesAsync();
    }
}