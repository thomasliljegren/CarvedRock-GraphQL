using CarvedRock.DataAccess.Repositories;
using CarvedRock.GraphQL.Types;
using GraphQL.Types;

namespace CarvedRock.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(
            IProductRepository productRepository,
            IProductReviewRepository reviewRepository)
        {
            Field<ListGraphType<ProductGraphType>>(
                "products",
                //GraphQL takes care of awaiting and converting product to product graph type
                resolve: context => productRepository.GetAllAsync());

            Field<ProductGraphType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetById(id);
                });

            Field<ListGraphType<ProductReviewGraphType>>(
                "reviews",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return reviewRepository.GetByProductIdAsync(id);
                });
        }
    }
}
