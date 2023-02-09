using CleanAdArch.Domain.Models.User;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface IUserRepository
{
    public Task Save(User user, CancellationToken cancellationToken);
    public Task<User?> OnById(Guid id,CancellationToken cancellationToken);

    public Task<User?> OnByEmail(string email,CancellationToken cancellationToken);
    public Task<bool> IsExist(string userLogin,string password, CancellationToken cancellationToken);
}