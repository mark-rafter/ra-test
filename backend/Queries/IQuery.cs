using System.Threading.Tasks;
using Backend.Services;

namespace Backend.Queries
{
    public interface IQuery<TResponse>
    {
        Task<TResponse> Resolve(DataContext dataContext);
    }
}
