using BackendApi.ApiTech.Domain.Models;

namespace BackendApi.ApiTech.Domain.Repositories;

public interface IAnalyticRepository
{
    Task<IEnumerable<Analytic>> ListAsync();
    Task AddAsync(Analytic analytic);
    Task<Analytic> FindByIdAsync(int id);
    Task<IEnumerable<Analytic>> ListByMonthAsync(int month);
    void Update(Analytic analytic);
    void Remove(Analytic analytic);
}