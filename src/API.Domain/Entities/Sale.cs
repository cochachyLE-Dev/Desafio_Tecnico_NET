﻿using System;
using System.Collections.Generic;

namespace API.Domain.Entities
{
    public class Sale
    {        
        public string? Serie { get; set; }
        public string? Number { get; set; }
        public int VendorId { get; set; }
        public double Total { get; set; }
        public DateTime DateOfIssue { get; set; }
        public Vendor? Vendor { get; set; }
        public List<SaleDetail>? SaleDetails { get; set; }
    }
}
