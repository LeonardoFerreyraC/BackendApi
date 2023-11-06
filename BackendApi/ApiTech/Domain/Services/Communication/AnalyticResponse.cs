using BackendApi.Shared.Domain.Services.Communication;
using BackendApi.ApiTech.Domain.Models;

namespace BackendApi.ApiTech.Domain.Services.Communication;

public class AnalyticResponse : BaseResponse<Analytic>
{
    public AnalyticResponse(string message) : base(message)
    {
    }

    public AnalyticResponse(Analytic resource) : base(resource)
    {
    }
}