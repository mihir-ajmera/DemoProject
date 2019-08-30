using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoProject.DAL;
using DemoProject.DTO;

namespace DemoProject.App_Start
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Country, CountryDto>()
                .ReverseMap();

                config.CreateMap<State, StateDto>()
                .ReverseMap();

                config.CreateMap<City, CityDto>()
                .ReverseMap();

                config.CreateMap<User, UserDto>()
                .ReverseMap();
            });
        }
    }
}