using WeatherApp.Data;
using WeatherApplication.Domain;

namespace WeatherApplication.Services
{
    public class AdminService : IAdminService
    {
        private readonly WeatherDbContext _context;

        public AdminService(WeatherDbContext context)
        {
            _context = context;
        }

        public List<SearchLogView> GetSearchLogStats()
        {
            var stats = _context.SearchLog.GroupBy(x => x.City).Select(x => new SearchLogView
            {
                City = x.Key,
                Count = x.Count()
            }).ToList();

            return stats;
        }
    }
}
