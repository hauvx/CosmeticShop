using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticShop.Models;

namespace CosmeticShop.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<CartItemViewModel> CartItemViewModels { get; set; }
    }
}