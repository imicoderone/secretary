using AutoMapper;
using Secretary.Application.DTOs.Responses;
using Secretary.Domain;
using System;

namespace Secretary.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Crowd, CrowdResponseDTO>();
        }
    }
}
