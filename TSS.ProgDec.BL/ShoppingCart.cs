using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.ProgDec.BL;

namespace TSS.ProgDec.BL
{
    public class ShoppingCart
    {
        const double ITEM_COST = 100;

        public ProgDecList Items { get; set; }

        public int TotalCount { get { return Items.Count;} }
        public double TotalCost { get; set; }


        public ShoppingCart()
        {
            Items = new ProgDecList();
        }

        public void Checkout ()
        {

        }

        public void Add(ProgDec progdec)
        {
            Items.Add(progdec);
            TotalCost += ITEM_COST;
        }

        public void Remove(ProgDec progdec)
        {
            Items.Remove(progdec);
            TotalCost -= ITEM_COST;
        }


    }
}
