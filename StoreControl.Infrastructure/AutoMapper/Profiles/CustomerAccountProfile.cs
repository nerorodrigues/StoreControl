using AutoMapper;
using StoreControl.Infrastructure.Database.Models;
using StoreControl.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreControl.Infrastructure.AutoMapper.Profiles
{
    public class CustomerAccountProfile : Profile
    {
        public CustomerAccountProfile()
        {
            CreateMap<CustomerAccount, CustomerAccountModel>();
            CreateMap<CustomerAccountModel, CustomerAccount>();
            CreateMap<CustomerAccount, CustomerAccount>();
        }
    }
}
