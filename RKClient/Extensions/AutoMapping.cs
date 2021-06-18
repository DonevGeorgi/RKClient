using AutoMapper;
using Client.Models.Models;
using Client.Models.Request;
using Client.Models.Response;
using System.Collections.Generic;

namespace RKClient.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ComputerResponse, Computer>().ReverseMap();
            CreateMap<ComputerRequest, Computer>().ReverseMap();
            CreateMap<IEnumerable<ComputerResponse>, IEnumerable<Computer>>();
        }
    }
}
