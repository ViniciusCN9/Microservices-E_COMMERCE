using Order.domain.Commands;

namespace Order.domain.Interfaces
{
    public interface IHandler
    {
        CreateOrderResponse Handle(CreateOrderRequest request);
        AddProductResponse Handle(AddProductRequest request);
        RemoveProductResponse Handle(RemoveProductRequest request);
    }
}