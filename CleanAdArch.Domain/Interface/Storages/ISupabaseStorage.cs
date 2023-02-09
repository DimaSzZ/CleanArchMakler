using Microsoft.AspNetCore.Http;

namespace CleanAdArch.Domain.Interface.Storages;

public interface ISupabaseStorage
{
    public Task<string?> Save(string nickname, IFormFile file);
}