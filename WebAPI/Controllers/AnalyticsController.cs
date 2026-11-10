using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController(IAnalyticsService analyticsService) : ControllerBase
{
    private IAnalyticsService service = analyticsService;

    [HttpGet("completion-rate")]
    public async Task<ApiResponse<decimal>> GetCompletionRate()
    {
        return await service.GetCompletionRateAsync();
    }
}