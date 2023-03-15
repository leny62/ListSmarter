using AutoMapper;
using ListSmarter.DTOs;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bucket, BucketDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}