using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Services;

namespace Backend.Queries
{
    public class GetEventsQuery : IQuery<IEnumerable<EventDto>>
    {
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public int AreaId { get; }

        public GetEventsQuery(DateTime fromDate, DateTime toDate)
        {
            FromDate = fromDate.ToLocalTime();
            ToDate = toDate.ToLocalTime();
        }

        public async Task<IEnumerable<EventDto>> Resolve(DataContext dataContext)
        {
            var events = await dataContext.GetEvents();
            return events
                .Where(e => e.Date >= FromDate)
                .Where(e => e.Date <= ToDate);
        }
    }
}
