﻿using CarvedRock.Api.GraphQL.Messaging;
using CarvedRock.Api.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockSubscription : ObjectGraphType
    {
        public CarvedRockSubscription(IReviewMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageGraphType),
                Resolver = new FuncFieldResolver<ReviewAddedMessage>(c => c.Source as ReviewAddedMessage),
                Subscriber = new EventStreamResolver<ReviewAddedMessage>(c => messageService.GetMessages())
            });
            // use AddField to add more subscription types.
        }
    }
}
