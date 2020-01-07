using CarvedRock.Web.Models;
using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Web.Clients
{
    public class ProductGraphClient : IProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                { products 
                    { id name price rating photoFileName }
                }"
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<IEnumerable<ProductModel>>("products");
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query productQuery($productId: ID!)
                { product(id: $productId)
                    {
                        id
                        name
                        price
                        rating
                        photoFileName
                        description
                        stock
                        IntroducedAt
                        reviews {
                            title 
                            review
                        }
                    }
                }",
                Variables = new { productId = id }
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<ProductModel>("product");
        }
    }
}
