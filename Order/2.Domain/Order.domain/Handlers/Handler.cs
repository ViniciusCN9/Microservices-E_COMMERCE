using System;
using System.Linq;
using Order.domain.Commands;
using Order.domain.Entities;
using Order.domain.Interfaces;
using Order.domain.Repositories;

namespace Order.domain.Handlers
{
    public class Handler : IHandler
    {
        private IOrderRepository _orderRepository;
        private IProductRequest _productRequest;

        public Handler(IOrderRepository orderRepository, IProductRequest productRequest)
        {
            _orderRepository = orderRepository;
            _productRequest = productRequest;
        }

        public CreateOrderResponse Handle(CreateOrderRequest request)
        {
            //Validação
            if (string.IsNullOrEmpty(request.Username))
                throw new Exception("Usuário inválido");

            //Valida se já existe pedido ativo
            var activeOrder = _orderRepository.VerifyOrder(request.Username);
            if (activeOrder)
                throw new Exception("Já existe pedido ativo");

            //Gera entidade
            var id = _orderRepository.GetNextId();
            var order = new Requirement(request.Username, id);

            //Salva informação
            _orderRepository.CreateOrder(order);

            //Cria resposta
            var response = new CreateOrderResponse();
            response.OrderId = id;

            //Retorna resposta
            return response;
        }

        public AddProductResponse Handle(AddProductRequest request, string username)
        {
            //Validação
            if (request.ProductId <= 0)
                throw new Exception("Produto inválido");

            //Busca Produto
            Product product;
            try
            {
                product = _productRequest.GetProduct(request.ProductId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            //Encontra pedido
            var order = _orderRepository.GetOrder(request.OrderId, username);
            if (order is null)
                throw new Exception("Pedido não encontrado");

            //Adiciona produto
            order.AddProduct(product);

            //Atualiza banco de dados
            _orderRepository.UpdateOrder(request.OrderId, order);

            //Retorna resposta
            return new AddProductResponse();
        }

        public RemoveProductResponse Handle(RemoveProductRequest request, string username)
        {
            //Validação
            if (request.OrderId <= 0 || request.ProductId <= 0)
                throw new Exception("Produto inválido");

            //Encontra pedido
            var order = _orderRepository.GetOrder(request.OrderId, username);
            if (order is null)
                throw new Exception("Pedido não encontrado");

            //Verifica se existe o produto
            var product = order.Products.FirstOrDefault(e => e.Id == request.ProductId);
            if (product is null)
                throw new Exception("Produto não encontrado no pedido");

            //Remove produto
            order.RemoveProduct(product);

            //Atualiza banco de dados
            _orderRepository.UpdateOrder(request.OrderId, order);

            //Retorna resposta
            return new RemoveProductResponse();
        }

        public FinishOrderResponse Handle(FinishOrderRequest request, string username)
        {
            //Validação
            if (request.OrderId <= 0)
                throw new Exception("Pedido inválido");

            //Encontra pedido
            var order = _orderRepository.GetOrder(request.OrderId, username);
            if (order is null)
                throw new Exception("Pedido não encontrado");

            //Finaliza pedido
            order.FinishOrder();

            //Atualiza banco de dados
            _orderRepository.UpdateOrder(request.OrderId, order);

            return new FinishOrderResponse();
        }
    }
}