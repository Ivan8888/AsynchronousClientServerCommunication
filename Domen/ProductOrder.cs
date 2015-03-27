using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domen
{
    public class ProductOrder
    {
        string simbol;
        public string Simbol
        {
            get { return simbol; }
            set { simbol = value; }
        }

        int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public override string ToString()
        {
            return simbol;
        }

    }
}
