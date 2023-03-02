using AutoMapper;
using ListSmarter.Repositories.Models;
using ListSmarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Bucket, BucketDto>().ReverseMap();
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Task, TaskDto>().ReverseMap();
    }
}