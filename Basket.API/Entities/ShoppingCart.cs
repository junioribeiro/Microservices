﻿namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = [];

        public ShoppingCart()
        {
            
        }
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(i => i.Price * i.Quantity);
            }
        }
    }
}
