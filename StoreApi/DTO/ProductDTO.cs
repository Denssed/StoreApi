﻿namespace StoreApi.Dto
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int IdBatch { get; set; }
        public int Quantity { get; set; }
    }
}
