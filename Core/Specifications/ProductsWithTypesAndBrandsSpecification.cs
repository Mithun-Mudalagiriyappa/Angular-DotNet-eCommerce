using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
            : base(x => 
                           (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Trim().Contains(productSpecParams.Search))
                        && (!productSpecParams.BrandID.HasValue || x.ProductBrandId == productSpecParams.BrandID)
                        && (!productSpecParams.TypeID.HasValue || x.ProductTypeId == productSpecParams.TypeID)
                  )
        {
            AddInclude(x => x.ProductBrand!);
            AddInclude(x => x.ProductType!);

            AddOrderBy(x => x.Name);

            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price!);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(x => x.Price!);
                        break;

                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int Id) : base(x => x.Id == Id)
        {
            AddInclude(x => x.ProductBrand!);
            AddInclude(x => x.ProductType!);
        }
    }
}
