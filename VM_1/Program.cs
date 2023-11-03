using System;
using System.Collections.Generic;
using System.Net;
using VM_1;

VendingMachineService vendingMachine = new VendingMachineService();

        Product drink = new Drink { Id = 1, Name = "Farta", Price = 120, Flavor = "Orange" };
        Product snack = new Snack { Id = 2, Name = "Chips", Price = 150, Description = "Potato chips with preservatives and chemicals" };
        Product chocolate = new Chocolate { Id = 3, Name = "Rappaello", Price = 250, Type = "White chocolate coconut balls" };

        vendingMachine.AddProduct(drink);
        vendingMachine.AddProduct(snack);
        vendingMachine.AddProduct(chocolate);

        Console.WriteLine("We welcome customers with sense of humor and ... big wallets!");
        Console.WriteLine("Choose among available products:");
        foreach (var productInfo in vendingMachine.ShowAll())
        {
            Console.WriteLine(productInfo);
        }

        while (true)
        {
            Console.WriteLine("Enter the ID of the product you want to buy (or 0 to exit):");
            if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0)
            {
                Console.WriteLine("Insert money (valid denominations: 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr, 1000kr):");
                if (int.TryParse(Console.ReadLine(), out int money) && Array.Exists(vendingMachine.ValidDenominations, d => d == money))
                {
                    vendingMachine.InsertMoney(money);
                    Product purchasedProduct = vendingMachine.Purchase(productId, vendingMachine.moneyPool);

                    if (purchasedProduct != null)
                    {
                        Console.WriteLine($"You've purchased: {purchasedProduct.Name}");
                        Console.WriteLine(purchasedProduct.Use());

                Dictionary<int, int> change = vendingMachine.EndTransaction(vendingMachine.moneyPool);
                foreach (var kvp in change)
                {
                    Console.WriteLine($"Your change: {kvp.Value} x {kvp.Key}kr");
                }
               // break;

            }
                    else
                    {
                        Console.WriteLine("Not enough money or product not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid money denomination.");
                }
            }
            else if (productId == 0)
            {
                Dictionary<int, int> change = vendingMachine.EndTransaction(vendingMachine.moneyPool);
                foreach (var kvp in change)
                {
                    Console.WriteLine($"{kvp.Value} x {kvp.Key}kr");
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid product ID.");
            }
        }
