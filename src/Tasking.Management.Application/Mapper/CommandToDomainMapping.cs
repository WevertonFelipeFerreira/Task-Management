using AutoMapper;
using Tasking.Management.Application.Commands.CreateUser;
using Tasking.Management.Domain.Entities;

namespace Tasking.Management.Application.Mapper
{
    public class CommandToDomainMapping : Profile
    {
        public CommandToDomainMapping()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Password, y => y.MapFrom(x => x.HashPassword))
                .ForMember(x => x.Address, y => y.Ignore())
                .ForMember(x => x.DeletedAt, y => y.Ignore())
                .ForMember(x => x.ModifiedAt, y => y.Ignore());
        }
    }
}
