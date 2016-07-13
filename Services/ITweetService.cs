using System.Threading.Tasks;

namespace Tweets10.Services
{
    public interface ITweetService
    {
        Task<string> GetAll();
    }
}
