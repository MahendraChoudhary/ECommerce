namespace ECommerce.Api.Products.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Db.Product, Models.Product>();
        }
    }
}
