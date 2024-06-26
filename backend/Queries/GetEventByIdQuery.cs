﻿using System;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Services;
using HotChocolate;

namespace Backend.Queries
{
    public class GetEventByIdQuery : IQuery<EventDto>
    {
        public int Id { get; }

        public GetEventByIdQuery(int id)
        {
            Id = id;
        }

        public async Task<EventDto> Resolve([Service] DataContext dataContext)
        {
            return await Task.FromResult<EventDto>(new EventDto()
            {
                Id = 1287430,
                Date = DateTime.Parse("2019-09-27T00:00:00"),
                StartTime = DateTime.Parse("2019-09-27T22:00:00"),
                EndTime = DateTime.Parse("2019-09-28T07:00:00"),
                Title = "Dubfire (Extended set) + Markantonio & Roberto Capuano",
                Attending = 455
            });
        }
    }
}
