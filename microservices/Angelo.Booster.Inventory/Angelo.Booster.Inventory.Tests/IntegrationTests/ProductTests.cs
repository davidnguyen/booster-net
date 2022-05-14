using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Angelo.Booster.Inventory.Service.Products;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Xunit;

namespace Angelo.Booster.Inventory.Tests.IntegrationTests;

public class ProductTests
{
    [Fact]
    public async Task Should_Return_Products()
    {
        ServicePointManager.ServerCertificateValidationCallback += 
            (sender, cert, chain, sslPolicyErrors) => true;
        var serviceUrl = Environment.GetEnvironmentVariable("SERVICE_URL")!;
        var client = new GraphQLHttpClient(serviceUrl, new NewtonsoftJsonSerializer());
        
        var request = new GraphQLRequest {
            Query = @"
            {
                products (category: ""halo"") {
                    id
                    name
                }
            }"
        };

        var response = await client.SendQueryAsync<GraphQLResponse<Product[]>>(request);
    }
}

public class GraphQLResponse<T>
{
    public T? Data { get; set; }
}