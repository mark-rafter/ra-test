using System;
using System.Collections.Generic;
using Backend.Dto;
using Backend.Queries;

namespace Backend
{
  public class Query
  {
    public IEnumerable<EventDto> Events(DateTime dateFrom, DateTime dateTo)
    {
      return new GetEventsQuery(dateFrom, dateTo).Resolve();
    }

    public EventDto Event(int id)
    {
      return new GetEventByIdQuery(id).Resolve();
    }
  }
}