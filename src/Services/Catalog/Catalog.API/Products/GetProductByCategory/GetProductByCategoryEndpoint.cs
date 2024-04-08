﻿namespace Catalog.API.Products.GetProductByCategory;

//public record GetProductByCategoryRequest(); 

public record GetProductByCategoryResponse(IEnumerable<Product> Products);


public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{categoryId}",
            async (string categoryId, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(categoryId));

            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);

        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products by category")
        .WithDescription("Get Products by category");

    }
}

