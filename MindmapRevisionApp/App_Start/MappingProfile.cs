using AutoMapper;
using MindmapRevisionApp.Dtos;
using MindmapRevisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindmapRevisionApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Mindmap, MindmapDto>();
            Mapper.CreateMap<MindmapDto, Mindmap>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}