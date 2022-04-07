using AutoMapper;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.PUT;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Mapper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {                        
            this.CreateMap<clsAspiranteDTO, clsAspirante>();
            this.CreateMap<clsAspirantePUT, clsAspirante>();
        }
    }
}
