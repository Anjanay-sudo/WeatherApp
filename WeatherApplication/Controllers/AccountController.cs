using Microsoft.AspNetCore.Mvc;
using WeatherApp.Data;
using WeatherApplication.Domain;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly WeatherDbContext _context;

    public AccountController(WeatherDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {
        var loginUser = _context.User.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        if (loginUser != null)
        {
            HttpContext.Session.SetString("Username", loginUser.Username);
            HttpContext.Session.SetString("Role", loginUser.Role);
            return Ok(new { Message = "Login successful" });
        }

        return Unauthorized(new { Message = "Invalid credentials" });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Ok(new { Message = "Logged out successfully" });
    }
}
