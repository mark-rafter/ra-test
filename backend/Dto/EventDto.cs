using System;
using HotChocolate;

namespace Backend.Dto
{
  [GraphQLName("Event")]
  public class EventDto
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public int? Attending { get; set; }
    public int VenueId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
  }
}
