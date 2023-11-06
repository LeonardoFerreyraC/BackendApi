using AutoMapper;
using BackendApi.ApiTech.Domain.Models;
using BackendApi.ApiTech.Resources;

namespace BackendApi.ApiTech.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAnalyticResource, Analytic>();
    }
}