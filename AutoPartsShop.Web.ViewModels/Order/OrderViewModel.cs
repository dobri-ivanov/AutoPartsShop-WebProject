using AutoPartsShop.Web.ViewModels.Customer;
using AutoPartsShop.Web.ViewModels.Part;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public PartInfoViewModel Part { get; set; } = null!;
        public CustomerFormModel Customer { get; set; } = null!;
    }
}
