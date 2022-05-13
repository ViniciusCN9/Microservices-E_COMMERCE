using Catalog.domain.Commands;

namespace Catalog.domain.Interfaces
{
    public interface IHandler
    {
        CreateProductResponse Handle(CreateProductRequest request);
    }
}