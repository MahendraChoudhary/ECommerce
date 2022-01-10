namespace ECommerce.Api.Orders.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Db.Order, Models.Order>();
            CreateMap<Db.OrderItem, Models.OrderItem>();
        }
    }
}
