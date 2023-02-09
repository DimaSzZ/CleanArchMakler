using System.Text.RegularExpressions;
using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.Ads;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class SearchRepository : ISearchRepository
{
    private readonly SupabaseDbContext _ctx;

    public SearchRepository(SupabaseDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<AdsShort>> Search(string? Heading, Guid? Category, Guid? SubCategory, string? City, CancellationToken cancellationToken)
    {
        var dataBase = _ctx.AdsEnumerable;
        if (City != null)
              dataBase
                 .Where(x => x.City.CityName == City);
        if (Category != null)
        {
              dataBase
                .Where(x => x.CategoryId == Category);
            if(SubCategory != null)
                 dataBase
                    .Where(x => x.SubCategoryId == SubCategory);
        }
        if (Heading != null)
        {
            var reg = new Regex($@"{Heading}(\w*)");
            dataBase.Where(x => reg.Matches(x.Heading).Count >= 1);   
        }

        return await dataBase
            .OrderByDescending(x => x.DateOfCreate)
            .Select(x=>x.GetShort())
            .ToListAsync(cancellationToken);
    }
}