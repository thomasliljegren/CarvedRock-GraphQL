using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Types
{
    public class ProductReviewInputGraphType : InputObjectGraphType
    {
        public ProductReviewInputGraphType()
        {
            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("review");
            Field<NonNullGraphType<IntGraphType>>("productId");
        }
        
    }
}
