using CleanAdArch.Domain.Models.EndpointLog;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface IEndpointLogRepository
{
    public Task Save(EndpointLog log);
}