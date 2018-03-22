using AutoMapper;
using StoreControl.Infrastructure.Database.Models;
using StoreControl.Shared.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreControl.Infrastructure.AutoMapper.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<Purchase, PurchaseModel>();
            CreateMap<PurchaseModel, Purchase>();
            CreateMap<Purchase, Purchase>();
        }
    }
}
