using CarvedRock.Entities;
using System;

namespace CarvedRock.Api.GraphQL.Messaging
{
    public interface IReviewMessageService
    {
        ReviewAddedMessage AddReviewAddedMessage(ProductReview review);
        IObservable<ReviewAddedMessage> GetMessages();
    }
}