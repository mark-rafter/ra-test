namespace Backend.Services
{
    public class DataContext
    {
        readonly string eventsJsonPath;

        readonly IReadOnlyList<EventDto>? cachedEventData;

        public DataContext(IWebHostEnvironment env)
        {
            eventsJsonPath = env.ContentRootPath 
                + Path.DirectorySeparatorChar
                + "data" 
                + Path.DirectorySeparatorChar 
                + "events.json";
        }

        public async ValueTask<IReadOnlyList<EventDto>> GetEvents()
        {
            if (cachedEventData is null)
            {
                using FileStream fs = File.OpenRead(eventsJsonPath);

                var eventData = await JsonSerializer.DeserializeAsync<IEnumerable<EventDto>>(fs)
                    ?? throw new InvalidOperationException($"No events found in {eventsJsonPath}");

                cachedEventData = eventData.ToList();
            }

            return cachedEventData;
        }

        public async Task<IEnumerable<EventDto>> GetEventsWithDateRange(DateTime from, DateTime to)
        {
            return cachedEventData.Where(e => e.Date >= from && e.Date <= to);
        }
    }
}