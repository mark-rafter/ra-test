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
        readonly string eventsJsonPath;

        IEnumerable<EventDto> cachedEventData;

        public DataContext(IWebHostEnvironment env)
        {
            eventsJsonPath = env.ContentRootPath
                + Path.DirectorySeparatorChar
                + "data"
                + Path.DirectorySeparatorChar
                + "events.json";
        }

        public async ValueTask<IEnumerable<EventDto>> GetEvents()
        {
            if (cachedEventData is null)
            {
                using FileStream fs = File.OpenRead(eventsJsonPath);

                var eventData = await JsonSerializer.DeserializeAsync<IEnumerable<EventDto>>(fs, new(JsonSerializerDefaults.Web))
                    ?? throw new InvalidOperationException($"No events found in {eventsJsonPath}");

                cachedEventData = eventData;
            }

            return cachedEventData;
        }
    }
}