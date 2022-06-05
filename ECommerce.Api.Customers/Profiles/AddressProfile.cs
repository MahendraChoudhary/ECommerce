namespace ECommerce.Api.Customers.Profiles
{
    public class AddressProfile : AutoMapper.Profile
    {
        public AddressProfile()
        {
            CreateMap<Db.Address, Models.Address>();
            CreateMap<Models.Address, Db.Address>()
                .ForMember("Id", m => m.Ignore());
        }
    }
}
