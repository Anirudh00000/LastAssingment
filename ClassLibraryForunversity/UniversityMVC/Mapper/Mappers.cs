using AutoMapper;
using ClassLibraryForunversity.Model;
using UniversityMVC.Models;

namespace UniversityMVC.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {

            CreateMap<University, UniversityModel>().ReverseMap();


        }


    }
}

