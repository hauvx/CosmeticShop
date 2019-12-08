using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CosmeticShop.Data;
using CosmeticShop.Models;
using CosmeticShop.ViewModels;

namespace CosmeticShop.ViewModels
{
    public class UserMyOrdersViewModel
    {
        public IEnumerable<UserMyOrderViewModel> MyOrderViewModels {get;set;}
        public IEnumerable<ProductType> ProductTypes {get;set;}
    }
}
