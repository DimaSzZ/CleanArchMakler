using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.User;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SupabaseDbContext _ctx;
    public UserRepository(SupabaseDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task Save(User? user, CancellationToken cancellationToken)
    {
        if (_ctx.Users.Contains(user))
        {
            _ctx.Users.Update(user);
        }
        else
            await _ctx.Users.AddAsync(user!, cancellationToken);

        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> OnById(Guid id, CancellationToken cancellationToken)
    {
        return await _ctx.Users
            .Where(user => user!.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User?> OnByEmail(string email, CancellationToken cancellationToken)
    {
        return await _ctx.Users
            .Where(user => user.Email == email)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsExist(string userLogin,string password, CancellationToken cancellationToken)
    {
        return await _ctx.Users
            .Where(user => user!.Email == userLogin && user.Password == password)
            .AnyAsync(cancellationToken);
    }
}