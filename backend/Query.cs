using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Queries;
using Backend.Services;
using HotChocolate;

namespace Backend
{
    public class Query
    {
        public async Task<IEnumerable<EventDto>> Events(DateTime dateFrom, DateTime dateTo, [Service] DataContext dataContext)
        {
            return await new GetEventsQuery(dateFrom, dateTo).Resolve(dataContext);
        }

        public async Task<EventDto> Event(int id, [Service] DataContext dataContext)
        {
            return await new GetEventByIdQuery(id).Resolve(dataContext);
        }
    }
}