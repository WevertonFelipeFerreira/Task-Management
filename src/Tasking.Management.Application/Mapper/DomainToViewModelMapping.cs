using AutoMapper;
using Tasking.Management.Application.ViewModels;
using Tasking.Management.Domain.Entities;

namespace Tasking.Management.Application.Mapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<User, CreateUserViewModel>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.Id));
        }
    }
}
