using AutoMapper;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Infrastructure.Data;

namespace StoreControl.Infrastructure.AutoMapper.Profiles
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<ViewModelBase, EntityModelBase<Guid>>();
            CreateMap<EntityModelBase<Guid>, ViewModelBase>();
            CreateMap<EntityModelBase<Guid>, EntityModelBase<Guid>>();
        }
    }
}
