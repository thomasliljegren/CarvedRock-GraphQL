using CarvedRock.Api.GraphQL.Messaging;
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
        public CarvedRockMutation(IProductReviewRepository reviewRepository, IReviewMessageService messageService)
        {
            FieldAsync<ProductReviewGraphType>(
                "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductReviewInputGraphType>> { Name = "review" }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    await reviewRepository.Create(review);
                    messageService.AddReviewAddedMessage(review);
                    return review;
                });
        }
    }
}
