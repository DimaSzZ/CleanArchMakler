using CleanAdArch.Domain.Models.City;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface ICityRepository
{
    public Task Save(City city,CancellationToken cancellationToken);
    
    public Task<List<City>> GetAll(CancellationToken cancellationToken);
    public Task<City> OneById(Guid id, CancellationToken cancellationToken);
    public Task Delete(City city, CancellationToken cancellationToken);
    public Task<bool> IsExistCity(string city, CancellationToken cancellationToken);
}