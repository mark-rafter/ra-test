using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Dto;
using Microsoft.AspNetCore.Hosting;

namespace Backend.Services
{
    public class DataContext
    {
        readonly string dataPath;

        IEnumerable<EventDto> cachedEventData;
        IEnumerable<VenueDto> cachedVenueData;
        IEnumerable<PromoterDto> cachedPromoterData;
        IEnumerable<ArtistDto> cachedArtistData;

        public DataContext(IWebHostEnvironment env)
        {
            dataPath = env.ContentRootPath
                + Path.DirectorySeparatorChar
                + "data"
                + Path.DirectorySeparatorChar;
        }

        public async ValueTask<IEnumerable<ArtistDto>> GetArtists()
        {
            cachedArtistData ??= await GetData<ArtistDto>("artists.json");
            return cachedArtistData;
        }

        public async ValueTask<IEnumerable<EventDto>> GetEvents()
        {
            cachedEventData ??= await GetData<EventDto>("events.json");
            return cachedEventData;
        }

        public async ValueTask<IEnumerable<VenueDto>> GetVenues()
        {
            cachedVenueData ??= await GetData<VenueDto>("venues.json");
            return cachedVenueData;
        }

        public async ValueTask<IEnumerable<PromoterDto>> GetPromoters()
        {
            cachedPromoterData ??= await GetData<PromoterDto>("promoters.json");
            return cachedPromoterData;
        }

        async Task<IEnumerable<TDto>> GetData<TDto>(string filename)
        {
            var filePath = dataPath + filename;

            using FileStream fs = File.OpenRead(filePath);

            var data = await JsonSerializer.DeserializeAsync<IEnumerable<TDto>>(fs, new(JsonSerializerDefaults.Web))
                ?? throw new InvalidOperationException($"No data found in {filePath}");

            return data;
        }
    }
}