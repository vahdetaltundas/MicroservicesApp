using AutoMapper;
using FreeCourse.Services.Catagol.Dtos;
using FreeCourse.Services.Catagol.Models;

namespace FreeCourse.Services.Catagol.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Feature,FeatureDto>().ReverseMap();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
