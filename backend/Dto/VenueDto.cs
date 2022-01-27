using HotChocolate;
using HotChocolate.Types;

namespace Backend.Dto
{
    [GraphQLName("Venue")]
    public class VenueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
