using System;
using System.Collections.Generic;
using Backend.Dto;

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

    public IEnumerable<EventDto> Resolve([Service] DataContext dataContext) {
      return dataContext.GetEvents();
      return dataContext.GetEventsWithDateRange(FromDate, ToDate);
      return new List<EventDto> {
        new EventDto() {
            Id=1287430,
            Date=DateTime.Parse("2019-09-27T00:00:00"),
            StartTime=DateTime.Parse("2019-09-27T22:00:00"),
            EndTime=DateTime.Parse("2019-09-28T07:00:00"),
            Title="Dubfire (Extended set) + Markantonio & Roberto Capuano",
            Attending=455
        },
        new EventDto() {
            Id=1280558,
            Date=DateTime.Parse("2019-09-27T00:00:00"),
            StartTime=DateTime.Parse("2019-09-27T22:00:00"),
            EndTime=DateTime.Parse("2019-09-28T06:00:00"),
            Title="1985 Music - London",
            Attending=361
          },
        new EventDto() {
            Id=1293272,
            Date=DateTime.Parse("2019-09-27T00:00:00"),
            StartTime=DateTime.Parse("2019-09-27T21:30:00"),
            EndTime=DateTime.Parse("2019-09-28T04:00:00"),
            Title="O'Flynn - Aletheia Album Tour",
            Attending=358
          },
        new EventDto() {
            Id=1293589,
            Date=DateTime.Parse("2019-09-27T00:00:00"),
            StartTime=DateTime.Parse("2019-09-27T22:00:00"),
            EndTime=DateTime.Parse("2019-09-28T04:00:00"),
            Title="Naturalia presents: Gerd Janson - All Night Long",
            Attending=349
          },
        new EventDto() {
            Id=1306343,
            Date=DateTime.Parse("2019-09-27T00:00:00"),
            StartTime=DateTime.Parse("2019-09-27T23:00:00"),
            EndTime=DateTime.Parse("2019-09-28T06:00:00"),
            Title="Fridays at EGG: Yousef, Dennis Cruz & Jansons",
            Attending=275
          },
        new EventDto() {
            Id=1302118,
            Date=DateTime.Parse("2019-09-27T00:00:00"),
            StartTime=DateTime.Parse("2019-09-27T21:30:00"),
            EndTime=DateTime.Parse("2019-09-28T04:00:00"),
            Title="Delta Heavy Curates: René Lavice, Teddy Killer, Gydra & Delta Heavy",
            Attending=181
          }
      };
    }
  }
}
