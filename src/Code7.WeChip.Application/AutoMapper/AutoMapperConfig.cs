using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code7.WeChip.Application.AutoMapper
{
    public class AutoMapperConfig
    {

        public static IMapper mapper;

        public static void RegisterMappings()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityModelProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}
