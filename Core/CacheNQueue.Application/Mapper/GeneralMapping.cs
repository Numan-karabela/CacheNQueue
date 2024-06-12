using AutoMapper;
using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Mapper
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product,ProductGettAllQueryResponse>().ReverseMap();
            //CreateMap<Product, ProductAddCommandReques>().ReverseMap();

        }
    }
}
