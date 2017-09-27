using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingJQMVC.Dtos;
using TestingJQMVC.Models;

namespace TestingJQMVC.App_Start
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ViewModel, ViewModelDto>();
            CreateMap<ViewModelDto, ViewModel>();
        }


    }
}