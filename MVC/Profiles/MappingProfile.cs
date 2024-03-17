using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using MVC.Models;

namespace MVC.Profiles;
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            this.CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }