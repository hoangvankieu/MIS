﻿namespace MIS.Entity
{
    public class Customer
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public List<StatisticCustomer> statisticCustomers { get; set; }
    }
}
