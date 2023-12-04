using AutoMapper;
using Labb1_MinimalAPI.Models;
using Labb1_MinimalAPI.Models.DTOs;

namespace Labb1_MinimalAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            
        }
    }
}
