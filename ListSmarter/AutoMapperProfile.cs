using AutoMapper;
using ListSmarter.Repositories.Models;
using ListSmarter.Models;
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
            CreateMap<Person, int>().ConvertUsing(p => p.Id);
            CreateMap<Task, int>().ConvertUsing(t => t.Id);
            CreateMap<Bucket, int>().ConvertUsing(b => b.Id);
        }
    }
}