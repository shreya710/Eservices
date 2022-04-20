using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NAGP.Services.OrderAPI.Entities
{
    public enum OrderStatusEnum {  Pending=0, Assigned=1, Denied = -1, Accepted = 2 }
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int ProviderId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        public OrderStatusEnum ConfirmStatus { get; set; } = OrderStatusEnum.Pending;
    }
}
