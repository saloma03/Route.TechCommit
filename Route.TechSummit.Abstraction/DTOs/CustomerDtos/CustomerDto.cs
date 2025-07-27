using System;
using System.Collections.Generic;
using Route.TechSummit.Application.DTOs.OrderDTOs;

namespace Route.TechSummit.Application.DTOs.CustomerDTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }

    public class CustomerCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CustomerUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}



