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

        public DataContext(IWebHostEnvironment env)
        {
            dataPath = env.ContentRootPath + Path.DirectorySeparatorChar + "data" + Path.DirectorySeparatorChar;
        }

        public async ValueTask<IEnumerable<EventDto>> GetEvents()
        {
            if (cachedEventData is null)
            {
                cachedEventData = await GetData<EventDto>("events.json");
            }

            return cachedEventData;
        }

        public async ValueTask<IEnumerable<VenueDto>> GetVenues()
        {
            if (cachedVenueData is null)
            {
                cachedVenueData = await GetData<VenueDto>("venues.json");
            }

            return cachedVenueData;
        }

        async ValueTask<IEnumerable<TDto>> GetData<TDto>(string filename)
        {
            var filePath = dataPath + filename;

            using FileStream fs = File.OpenRead(filePath);

            var data = await JsonSerializer.DeserializeAsync<IEnumerable<TDto>>(fs, new(JsonSerializerDefaults.Web))
                ?? throw new InvalidOperationException($"No data found in {filePath}");

            return data;
        }
    }
}