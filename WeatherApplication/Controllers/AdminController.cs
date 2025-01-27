using Microsoft.AspNetCore.Mvc;
using WeatherApp.Data;
using WeatherApplication.Services;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly WeatherDbContext _context;
    private readonly IAdminService _adminService;

    public AdminController(WeatherDbContext context, IAdminService adminService)
    {
        _context = context;
        _adminService = adminService;
    }

    [HttpPost("toggle-weather-access")]
    public IActionResult ToggleWeatherAccess([FromBody] bool enable)
    {
        // Only allow admins to toggle access
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized(new { Message = "Admin access required" });

        // Logic to enable or disable weather access
        HttpContext.Session.SetString("WeatherAccessEnabled", enable.ToString());

        return Ok(new { Message = $"Weather access is now {(enable ? "enabled" : "disabled")}" });
    }

    [HttpGet("statistics")]
    public IActionResult GetSearchStatistics()
    {
        // Only allow admins to view search statistics
        if (HttpContext.Session.GetString("Role") != "Admin")
            return Unauthorized(new { Message = "Admin access required" });

        var stats = _adminService.GetSearchLogStats();
        return Ok(stats);
    }
}
