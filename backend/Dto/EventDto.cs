using System;
using System.Collections.Generic;
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
        public int[] ArtistIds { get; set; }
        public async IAsyncEnumerable<ArtistDto> Artists([Service] DataContext dataContext)
        {
            var artists = await dataContext.GetArtists();
            foreach (var artistId in ArtistIds)
            {
                yield return artists.FirstOrDefault(a => a.Id == artistId);
            }
        }
        public int[] PromoterIds { get; set; }
        public async IAsyncEnumerable<PromoterDto> Promoters([Service] DataContext dataContext)
        {
            var promoters = await dataContext.GetPromoters();
            foreach (var promoterId in PromoterIds)
            {
                yield return promoters.FirstOrDefault(p => p.Id == promoterId);
            }
        }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
