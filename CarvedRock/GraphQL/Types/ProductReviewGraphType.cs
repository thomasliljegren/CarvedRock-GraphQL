using CarvedRock.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.GraphQL.Types
{
    public class ProductReviewGraphType : ObjectGraphType<ProductReview>
    {
        public ProductReviewGraphType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
