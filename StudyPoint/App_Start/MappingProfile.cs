using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StudyPoint.Dtos;
using StudyPoint.Models;

namespace StudyPoint.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<CourseDto, Course>().ForMember(c => c.Id, opt => opt.Ignore());


            Mapper.CreateMap<CourseDifficultyLevel, CourseDifficultyLevelDto>();
            

        }
    }
}