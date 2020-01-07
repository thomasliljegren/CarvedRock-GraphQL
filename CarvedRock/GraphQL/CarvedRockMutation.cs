using CarvedRock.Api.GraphQL.Types;
using CarvedRock.DataAccess.Repositories;
using CarvedRock.Entities;
using CarvedRock.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockMutation : ObjectGraphType
    {
        public CarvedRockMutation(IProductReviewRepository reviewRepository)
        {
            FieldAsync<ProductReviewGraphType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputGraphType>> { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    return await context.TryAsyncResolve(async c => await reviewRepository.Create(review));
                });
        }
    }
}
