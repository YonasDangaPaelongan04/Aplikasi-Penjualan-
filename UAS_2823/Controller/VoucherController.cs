using System;
using System.Collections.Generic;
using System.Text;
using UAS_2823.Model;

namespace UAS_2823.Controller
{
    class VoucherController
    {
        private List<Voucher> items;

        public VoucherController()
        {
            items = new List<Voucher>();
        }

        public void addItem(Voucher item)
        {
            this.items.Add(item);
        }

        public List<Voucher> getItems()
        {
            return this.items;
        }
    }
}