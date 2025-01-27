using WeatherApplication.Domain;

namespace WeatherApplication.Services
{
    public interface IAdminService
    {
        public List<SearchLogView> GetSearchLogStats();
    }
}
