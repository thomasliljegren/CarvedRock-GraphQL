using CarvedRock.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.GraphQL.Types
{
    public class ProductTypeEnumGraphType : EnumerationGraphType<ProductType>
    {
        public ProductTypeEnumGraphType()
        {
            Name = "Type";
            Description = "The type of the product";
        }
    }
}
