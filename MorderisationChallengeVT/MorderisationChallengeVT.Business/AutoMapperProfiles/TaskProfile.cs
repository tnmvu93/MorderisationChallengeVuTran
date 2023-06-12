using AutoMapper;
using MorderisationChallengeVT.Contracts.DTOs;

namespace MorderisationChallengeVT.Business.AutoMapperProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Domain.Entities.Task, TaskDTO>();
            CreateMap<TaskDTO, Domain.Entities.Task>();
        }
    }
}
