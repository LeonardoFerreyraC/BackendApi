﻿using AutoMapper;
using BackendApi.Shared.Extensions;
using BackendApi.ApiTech.Domain.Models;
using BackendApi.ApiTech.Domain.Services;
using BackendApi.ApiTech.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.ApiTech.Controllers;

[ApiController]
[Route("api/v1/analytics")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticService _analyticService;
    private readonly IMapper _mapper;

    public AnalyticsController(IAnalyticService analyticService, IMapper mapper)
    {
        _analyticService = analyticService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AnalyticResource>> GetAllAsync()
    {
        var analytics = await _analyticService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Analytic>, 
            IEnumerable<AnalyticResource>>(analytics);
        return resources;

    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveAnalyticResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var category = _mapper.Map<SaveAnalyticResource, 
            Analytic>(resource);
        var result = await _analyticService.SaveAsync(category);
        if (!result.Success)
            return BadRequest(result.Message);
        var categoryResource = _mapper.Map<Analytic, 
            AnalyticResource>(result.Resource);
        return Ok(categoryResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveAnalyticResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
 
        var category = _mapper.Map<SaveAnalyticResource, 
            Analytic>(resource);
        var result = await _analyticService.UpdateAsync(id, category);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var categoryResource = _mapper.Map<Analytic, 
            AnalyticResource>(result.Resource);
        return Ok(categoryResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _analyticService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
 
        var categoryResource = _mapper.Map<Analytic, 
            AnalyticResource>(result.Resource);
        return Ok(categoryResource);
    }

}