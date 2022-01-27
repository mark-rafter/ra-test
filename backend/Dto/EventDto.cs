using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services;
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
        public async Task<VenueDto> Venue([Service] DataContext dataContext)
        {
            var venues = await dataContext.GetVenues();
            return venues.FirstOrDefault(v => v.Id == VenueId);
        }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
