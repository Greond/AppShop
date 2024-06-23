using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.DataBase
{
    class ItemsDataBase
    {
        public ItemsDataBase() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double price { get; set; }
        public double oldprice{ get; set; }
        public bool stock { get; set; }
        public ImageSource icon { get; set; }


    }
}
