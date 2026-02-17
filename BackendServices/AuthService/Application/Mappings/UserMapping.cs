using Application.DTOs;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class UserMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SignupDto, User>();
            config.NewConfig<User, UserDto>()
                .Map(dest => dest.Roles, src => src.Roles.Select(r => r.RoleName).ToList());
            config.NewConfig<LoginDto, User>()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Password, src => src.Password);

        }
    }
}
