using DataBaseMicroService.DTO;

namespace DataBaseMicroService.Extensions
{
    public static class MappingExtensions
    {
        public static ElectricityPrice ToEntity(this PriceInfo priceInfo)
        {
            return new ElectricityPrice
            {
                StartDate = priceInfo.StartDate,
                EndDate = priceInfo.EndDate,
                Price = priceInfo.Price
            };
        }
    }

    
}
