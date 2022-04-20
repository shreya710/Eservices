﻿using Microsoft.AspNetCore.Mvc;
using NAGP.Services.OrderAPI.Entities;
using NAGP.Services.OrderAPI.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NAGP.Services.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public enum OrderDecisionEnum { Denied = -1, Accepted = 2 }
        private readonly OrderRepository orderRepository;
        public OrderController()
        {
            orderRepository = new OrderRepository();
        }
        // GET: api/<OrderController>
        [HttpGet]
        public List<Order> GetOrders()
        {
            return orderRepository.Orders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order GetOrder(int id)
        {
            return orderRepository.OrderById(id);
        }

        // POST api/<OrderController>
        [HttpGet("status/{id}")]
        public OrderStatusEnum GetOrderStatus(int id)
        {
            return orderRepository.OrderById(id).ConfirmStatus;
        }

        [HttpPost]
        public Order PlaceOrder([FromBody] Order order)
        {
            return orderRepository.AddOrder(order);
        }

        [HttpGet("Customer")]
        public List<Order> GetCustomerOrders(int id)
        {
            return orderRepository.CustomerOrders(id);
        }

        [HttpGet("Customer/{id}/{customerId}")]
        public Order GetOrderDetails(int id, int customerId)
        {
            // Also need to Provide Provider details 
            return orderRepository.CustomerOrder(id,customerId);
        }

        [HttpGet("Provider")]
        public List<Order> GetProviderOrders(int id)
        {
            return orderRepository.ProviderOrders(id);
        }

        [HttpGet("Provider/{id}/{providerId}")]
        public Order GetProviderOrder(int id, int providerId)
        {
            // Also need to Provide Customer details 
            return orderRepository.ProviderOrder(id,providerId);
        }

        [HttpPost("Provider/{id}")]
        public Order ProviderOrderDecision(int id, [FromBody] OrderDecisionEnum decision)
        {
            return orderRepository.OrderProviderDecision(id, (OrderStatusEnum)decision);
        }

        [HttpGet("Pending")]
        public List<Order> GetPendingOrders()
        {
            return orderRepository.PendingOrders();
        }

        [HttpPut("Assign")]
        public Order OrdersAssignment([FromBody]Order order)
        {
            return orderRepository.UpdateOrder(order);
        }
    }
}
