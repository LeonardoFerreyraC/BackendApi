using AutoMapper;
using BackendApi.ApiTech.Domain.Models;
using BackendApi.ApiTech.Domain.Services;
using BackendApi.ApiTech.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.ApiTech.Controllers;

[ApiController]
[Route("api/v1/month/{month}/analytics")]
public class MonthAnalyticsController : ControllerBase
{
    private readonly IAnalyticService _analyticService;
    private readonly IMapper _mapper;

    public MonthAnalyticsController(IAnalyticService analyticService, IMapper mapper)
    {
        _analyticService = analyticService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AnalyticResource>> GetAllByMonthAsync(int month)
    {
        var analytics = await _analyticService.ListByMonthAsync(month);
        var resources = _mapper.Map<IEnumerable<Analytic>, 
            IEnumerable<AnalyticResource>>(analytics);
        return resources;
    }
}