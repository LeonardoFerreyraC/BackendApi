using AutoMapper;
using BackendApi.ApiTech.Domain.Models;
using BackendApi.ApiTech.Resources;

namespace BackendApi.ApiTech.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Analytic, AnalyticResource>();
    }
}