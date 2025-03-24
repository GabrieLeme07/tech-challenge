using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

public static class CreateSaleHandlerTestData
{
    public static CreateSaleCommand GenerateValidCommand()
    {
        return new Faker<CreateSaleCommand>("pt_BR")
            .CustomInstantiator(f => new CreateSaleCommand
            {
                CartId = 1,
                CustomerId = 1,
                Branch = f.Company.CompanyName()
            });
    }
}
