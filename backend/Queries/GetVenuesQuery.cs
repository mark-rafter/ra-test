using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Services;
using HotChocolate;

namespace Backend.Queries
{
    public class GetVenuesQuery : IQuery<IEnumerable<VenueDto>>
    {
        public async Task<IEnumerable<VenueDto>> Resolve([Service] DataContext dataContext)
        {
            return await dataContext.GetVenues();
        }
    }
}
