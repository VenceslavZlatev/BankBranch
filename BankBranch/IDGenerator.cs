using System;
using System.Collections.Generic;
using System.Text;

namespace BankBranch

{
    class IDGenerator
    {
        string storeId;

        Random rnd = new Random();
        public string generate()
        {
            storeId = rnd.Next().ToString();
            return storeId;

        }

    }
}

