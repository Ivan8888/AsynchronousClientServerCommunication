using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domen
{
    public class ProductInfo
    {
        string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        string simbol;
        public string Simbol
        {
            get { return simbol; }
            set { simbol = value; }
        }

        string currency;
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public override string ToString()
        {
            return fullName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is ProductInfo))
            {
                return false;
            }

            return this.simbol == ((ProductInfo)obj).simbol;
        }

    }
}
