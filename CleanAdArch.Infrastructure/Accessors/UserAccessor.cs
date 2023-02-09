using CleanAdArch.Domain.Interface.Accessors;
using CleanAdArch.Domain.Models.User;
using Microsoft.AspNetCore.Http;

namespace CleanAdArch.Infrastructure.Accessors;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _accessor;

    public UserAccessor(
        IHttpContextAccessor accessor
    )
    {
        _accessor = accessor;
    }
    public User? Get()
    {
        return (User?)_accessor.HttpContext?.Items["User"];
    }
}