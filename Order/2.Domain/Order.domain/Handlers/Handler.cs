using System;
using System.Linq;
using MongoDB.Bson;
using Order.domain.Commands;
using Order.domain.Entities;
using Order.domain.Interfaces;
using Order.domain.Repositories;

namespace Order.domain.Handlers
{
    public class Handler : IHandler
    {
        private IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public CreateOrderResponse Handle(CreateOrderRequest request)
        {
            //Validação
            if (string.IsNullOrEmpty(request.Username))
                throw new Exception("Usuário inválido");

            //Gera entidade
            var order = new Requirement(request.Username);

            //Salva informação
            _orderRepository.CreateOrder(order);

            //Retorna resposta
            return new CreateOrderResponse();
        }

        public AddProductResponse Handle(AddProductRequest request)
        {
            //Validação
            if (request.ProductId <= 0 || string.IsNullOrEmpty(request.Description) || request.Price == 0m)
                throw new Exception("Produto inválido");

            //Gera entidade
            var product = new Product(request.ProductId, request.Description, request.Price);

            //Encontra pedido
            var orderId = ObjectId.Parse(request.OrderId.ToString());
            var order = _orderRepository.GetOrder(orderId);
            if (order is null)
                throw new Exception("Pedido não encontrado");

            //Adiciona produto
            order.AddProduct(product);

            //Retorna resposta
            return new AddProductResponse();
        }

        public RemoveProductResponse Handle(RemoveProductRequest request)
        {
            //Validação
            if (request.OrderId <= 0 || request.ProductId <= 0)
                throw new Exception("Produto inválido");

            //Encontra pedido
            var orderId = ObjectId.Parse(request.OrderId.ToString());
            var order = _orderRepository.GetOrder(orderId);
            if (order is null)
                throw new Exception("Pedido não encontrado");

            //Verifica se existe o produto
            var product = order.Products.FirstOrDefault(e => e.Id == request.ProductId);
            if (product is null)
                throw new Exception("Produto não encontrado no pedido");

            //Remove produto
            order.RemoveProduct(product);

            //Retorna resposta
            return new RemoveProductResponse();
        }
    }
}