using AutoMapper;
using ListSmarter.Buckets.Dtos;
using ListSmarter.Buckets.Repository.Models;
using ListSmarter.People.Dtos;
using ListSmarter.People.Repository.Models;
using ListSmarter.Tasks.Dtos;
using Task = ListSmarter.Tasks.Repository.Models.Task;

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