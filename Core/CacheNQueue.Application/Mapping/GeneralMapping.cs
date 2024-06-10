using AutoMapper;
using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CacheNQueue.Domain.Entities.Product, ProductAddCommandReques>().ReverseMap();
        }
    }
}
