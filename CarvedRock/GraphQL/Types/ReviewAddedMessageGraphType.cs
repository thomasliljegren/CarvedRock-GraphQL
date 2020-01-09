using CarvedRock.Api.GraphQL.Messaging;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ReviewAddedMessageGraphType : ObjectGraphType<ReviewAddedMessage>
    {
        public ReviewAddedMessageGraphType()
        {
            Field(t => t.ProductId);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
