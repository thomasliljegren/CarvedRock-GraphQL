using CarvedRock.DataAccess.Repositories;
using CarvedRock.Entities;
using CarvedRock.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.GraphQL
{
    public class CarvedRockQuery : ObjectGraphType
    {
        public CarvedRockQuery(IProductRepository repo)
        {
            Field<ListGraphType<ProductGraphType>>(
                "products",
                //GraphQL takes care of awaiting and converting product to product graph type
                resolve: context => repo.GetAllAsync()
            );
        }
    }
}
