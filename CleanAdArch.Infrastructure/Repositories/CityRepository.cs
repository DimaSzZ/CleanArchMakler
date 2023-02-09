using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.City;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly SupabaseDbContext _ctx;
    public CityRepository(SupabaseDbContext ctx)
    {
        _ctx = ctx;
    }
    public async Task Save(City city, CancellationToken cancellationToken)
    {
        if (_ctx.Cities.Contains(city))
        {
            _ctx.Update(city);
        }
        else
            await _ctx.Cities.AddAsync(city, cancellationToken);

        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<City>> GetAll(CancellationToken cancellationToken)
    {
        return await _ctx.Cities.ToListAsync(cancellationToken);
    }

    public async Task<List<City>> GetAll()
    {
        return await _ctx.Cities.ToListAsync();
    }

    public async Task<City?> OneById(Guid id, CancellationToken cancellationToken)
    {
        return await _ctx.Cities
            .Where(city => city.Id == id)
            .Select(city => 
                city)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Delete(City city, CancellationToken cancellationToken)
    {
        _ctx.Cities.Remove(city);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistCity(string cityIn, CancellationToken cancellationToken)
    {
        return await _ctx.Cities
            .Where(city => city.CityName == cityIn)
            .AnyAsync(cancellationToken);
    }
}