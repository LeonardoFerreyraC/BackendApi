using AutoMapper;
using BackendApi.Security.Domain.Models;
using BackendApi.Security.Resources;
using BackendApi.Security.Services.Communication;

namespace BackendApi.Security.Mapping;
public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResources>();
    }
}