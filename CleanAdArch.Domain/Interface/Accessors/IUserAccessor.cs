using CleanAdArch.Domain.Models.User;

namespace CleanAdArch.Domain.Interface.Accessors;

public interface IUserAccessor
{
    public User? Get();
}