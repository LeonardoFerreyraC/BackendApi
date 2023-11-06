using BackendApi.ApiTech.Domain.Models;
using BackendApi.ApiTech.Domain.Services.Communication;

namespace BackendApi.ApiTech.Domain.Services;

public interface IAnalyticService
{
    Task<IEnumerable<Analytic>> ListByMonthAsync(int month);
    Task<AnalyticResponse> SaveAsync(Analytic analytic);
    Task<AnalyticResponse> UpdateAsync(int id, Analytic analytic);
    Task<AnalyticResponse> DeleteAsync(int id);
    Task<IEnumerable<Analytic>> ListAsync();
}