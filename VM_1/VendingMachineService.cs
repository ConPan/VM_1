using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_1
{
    // Vending machine service class
    class VendingMachineService : IVending
    {
        private List<Product> products;
        public int moneyPool;
        public readonly int[] ValidDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };

        public VendingMachineService()
        {
            products = new List<Product>();
            moneyPool = 0;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product Purchase(int productId, int moneyPool)
        {
            Product product = products.Find(p => p.Id == productId);
            if (product != null && moneyPool >= product.Price)
            {
                this.moneyPool -= product.Price;
                return product;
            }
            return null;
        }

        public List<string> ShowAll()
        {
            List<string> productInfo = new List<string>();
            foreach (var product in products)
            {
                productInfo.Add($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price} kr");
            }
            return productInfo;
        }

        public string Details(int productId)
        {
            Product product = products.Find(p => p.Id == productId);
            if (product != null)
            {
                return product.Examine();
            }
            return "Product not found.";
        }

        public void InsertMoney(int amount)
        {
            if (Array.Exists(ValidDenominations, d => d == amount))
            {
                moneyPool += amount;
            }
            else
            {
                throw new ArgumentException("Invalid money denomination.");
            }
        }

        public Dictionary<int, int> EndTransaction(int moneyPool)
        {
            Dictionary<int, int> change = new Dictionary<int, int>();
            int remainingAmount = moneyPool;

            for (int i = ValidDenominations.Length - 1; i >= 0; i--)
            {
                int denomination = ValidDenominations[i];
                if (remainingAmount >= denomination)
                {
                    int count = remainingAmount / denomination;
                    change.Add(denomination, count);
                    remainingAmount %= denomination;
                }
            }

            if (remainingAmount == 0)
            {
                this.moneyPool = 0;
                return change;
            }
            else
            {
                throw new InvalidOperationException("Cannot provide exact change.");
            }
        }
    }
}
