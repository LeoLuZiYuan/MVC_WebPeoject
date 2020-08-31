using System.Diagnostics;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipTypes, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, 
                opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, 
                    opt => opt.Ignore());
        }
    }
}