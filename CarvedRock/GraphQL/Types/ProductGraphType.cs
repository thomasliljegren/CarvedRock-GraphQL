using CarvedRock.DataAccess.Repositories;
using CarvedRock.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.GraphQL.Types
{
    public class ProductGraphType : ObjectGraphType<Product>
    {
        public ProductGraphType(IProductReviewRepository productReviewRepository)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("Name of the product");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("Date of product introduction");
            Field(t => t.Price);
            Field(t => t.Stock).Description("Amount in stock");
            Field(t => t.Rating).Description("Product rating (1-5)");
            Field(t => t.PhotoFileName).Description("Photo file name that lets the client request the photo");
            Field<ProductTypeEnumGraphType>("Type", "Type of product");
            Field<ListGraphType<ProductReviewGraphType>>(
                "reviews",
                resolve: context => productReviewRepository.GetByProductIdAsync(context.Source.Id)
                );
            
        }
    }
}
