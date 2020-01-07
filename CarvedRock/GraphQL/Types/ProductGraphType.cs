using CarvedRock.Api.GraphQL.Types;
using CarvedRock.DataAccess.Repositories;
using CarvedRock.Entities;
using GraphQL.DataLoader;
using GraphQL.Types;
using System.Security.Claims;

namespace CarvedRock.GraphQL.Types
{
    public class ProductGraphType : ObjectGraphType<Product>
    {
        public ProductGraphType(IProductReviewRepository productReviewRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("Name of the product");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("Date of product introduction");
            Field(t => t.Price);
            Field(t => t.Stock).Description("Amount in stock");
            Field(t => t.Rating).Description("Product rating (1-5)");
            Field(t => t.PhotoFileName).Description("Photo file name that lets the client request the photo");
            Field<ProductTypeGraphType>("ProductType", "Type of product");
            Field<ListGraphType<ProductReviewGraphType>>(
                "reviews",
                resolve: context =>
                {
                    var user = (ClaimsPrincipal)context.UserContext;
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>("GetReviewsByProductId", productReviewRepository.GetByProductIdsAsync);
                    return loader.LoadAsync(context.Source.Id);
                });

        }
    }
}
