using BackendApi.Shared.Persistence.Contexts;
using BackendApi.Shared.Persistence.Repositories;
using BackendApi.ApiTech.Domain.Models;
using BackendApi.ApiTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.ApiTech.Persistence.Repositories;

public class AnalyticsRepository : BaseRepository, IAnalyticRepository
{
    public AnalyticsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Analytic>> ListAsync()
    {
        return await _context.Analytics.ToListAsync();
    }

    public async Task AddAsync(Analytic analytic)
    {
        await _context.Analytics.AddAsync(analytic);
    }

    public async Task<Analytic> FindByIdAsync(int id)
    {
        return await _context.Analytics.FindAsync(id);
    }

    public async Task<IEnumerable<Analytic>> ListByMonthAsync(int month)
    {
        return await _context.Analytics
            .Where(p => p.Month == month)
            .ToListAsync();
    }

    public void Update(Analytic analytic)
    {
        _context.Analytics.Update(analytic);
    }

    public void Remove(Analytic analytic)
    {
        _context.Analytics.Remove(analytic);
    }
}