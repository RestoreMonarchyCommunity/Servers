﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public short ProductId { get; set; }
        public string PlayerId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
