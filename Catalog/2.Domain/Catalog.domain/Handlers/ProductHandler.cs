using System;
using Catalog.domain.Commands;
using Catalog.domain.Entities;
using Catalog.domain.Enums;
using Catalog.domain.Interfaces;
using Catalog.domain.Repositories;

namespace Catalog.domain.Handlers
{
    public class ProductHandler : IHandler
    {
        private IProductRepository _productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public CreateProductResponse Handle(CreateProductRequest request)
        {
            //Validações
            if (string.IsNullOrEmpty(request.Description) || request.Price <= 0 || request.Category < 1 && request.Category > 3)
                throw new Exception("Informações inválidas");

            if (request.Description.Length < 5 && request.Description.Length > 40)
                throw new Exception("Descrição inválida");

            //Define categoria
            ECategory category;
            switch (request.Category)
            {
                case 1:
                    category = ECategory.NOTEBOOK;
                    break;
                case 2:
                    category = ECategory.DESKTOP;
                    break;
                case 3:
                    category = ECategory.MOBILE;
                    break;
                default:
                    throw new Exception("Categoria inválida");
            }

            //Gera entidade
            var product = new Product(request.Description, request.Price, category);

            //Salva informação
            _productRepository.CreateProduct(product);

            //Retorna resposta
            return new CreateProductResponse();
        }
    }
}