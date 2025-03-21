namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{ 
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }

    public string Branch { get; set; } = string.Empty;
    public List<CreateSaleItemRequest> Products { get; set; } = new List<CreateSaleItemRequest>(); 
}
