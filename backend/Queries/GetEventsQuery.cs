using System;
using System.Collections.Generic;
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
            FromDate = fromDate;
            ToDate = toDate;
        }

        public async Task<IEnumerable<EventDto>> Resolve(DataContext dataContext)
        {
            return await dataContext.GetEvents();
            // return dataContext.GetEventsWithDateRange(FromDate, ToDate);
        }
    }
}
