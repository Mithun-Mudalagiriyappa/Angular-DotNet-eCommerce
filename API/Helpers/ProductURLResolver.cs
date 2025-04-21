using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductURLResolver : IValueResolver<Product, ProductToReturnDTO, string?>
    {
        private readonly IConfiguration _configuration;

        public ProductURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Product source, ProductToReturnDTO destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Empty;
            }

            return _configuration["APIURL"] + source.PictureUrl;
        }
    }
}
