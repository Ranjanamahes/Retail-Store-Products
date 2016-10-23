using AutoMapper;
using RetailStore.Entity;
using RetailStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailStore.DataAccess.Common
{
    public static class  DataAutoMapper
    {
        public static MapperConfiguration config;
        public static IMapper mapper;
        public static void BootStrap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RetailStore_spr_GetAllProducts_Result, ProductModel>();
                cfg.CreateMap<RetailStore_spr_GetProductByID_Result, ProductModel>();
                cfg.CreateMap<RetailStore_spr_GetProductByCategoryName_Result, ProductModel>();

            });
            mapper = config.CreateMapper();
        }
    }
}
