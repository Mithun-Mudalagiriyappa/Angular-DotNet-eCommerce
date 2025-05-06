using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
             : base(x =>
                            (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Trim().Contains(productSpecParams.Search))
                        && (!productSpecParams.BrandID.HasValue || x.ProductBrandId == productSpecParams.BrandID)
                        && (!productSpecParams.TypeID.HasValue || x.ProductTypeId == productSpecParams.TypeID)
                  )
        {
        }
    }
}
