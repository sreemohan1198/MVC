﻿namespace CustomersMvc.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
