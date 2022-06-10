using Order.domain.Commands;

namespace Order.domain.Interfaces
{
    public interface IHandler
    {
        CreateOrderResponse Handle(CreateOrderRequest request);
        AddProductResponse Handle(AddProductRequest request, string username);
        RemoveProductResponse Handle(RemoveProductRequest request, string username);
        FinishOrderResponse Handle(FinishOrderRequest request, string username);
    }
}