using Library.eCommerce.Services;
using Spring2025_Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.eCommerce.ViewModels
{
    public class ProductViewModel
    {
        public string? Name { 
            get
            {
                return Model?.Name ?? string.Empty;
            }

            set
            {
                if(Model != null && Model.Name != value)
                {
                    Model.Name = value;
                }
            }
        }
        public decimal Price
        {
            get => Model?.Price ?? 0m;
            set
            {
                if(Model != null)
                {
                    Model.Price = value;
                }
            }
        }
        public int Quantity
        {
            get => Model?.Quantity ?? 0;
            set
            {
                if(Model != null)
                {
                    Model.Quantity = value;
                }
            }
        }

        public Product? Model { get; set; }

        public void AddOrUpdate()
        {
            if (Model != null)
            {
                var item = new Library.eCommerce.Models.Item(
                    Model.Name ?? string.Empty, 
                    Model, 
                    Quantity  // Pass the quantity to the Item constructor
                );
                InventoryServiceProxy.Current.AddOrUpdate(item);
            }
        }

        public ProductViewModel() {
            Model = new Product();
        }

        public ProductViewModel(Product? model)
        {
            Model = model;
        }
    }
}