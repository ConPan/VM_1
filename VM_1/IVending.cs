using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_1
{
    // Interface for vending machine service
    interface IVending
    {
        Product Purchase(int productId, int moneyPool);
        List<string> ShowAll();
        string Details(int productId);
        void InsertMoney(int amount);
        Dictionary<int, int> EndTransaction(int moneyPool);
    }
}
