using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.DataBase
{
    class ItemsData
    {
        public ItemsData() { }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public double OldPrice{ get; set; }
        public bool Stock { get; set; }
        public ImageSource Icon { get; set; }
        public int Stars { get; set; }
        public int ReviewsCount { get; set; }
        public List<string> Images { get; set; }

    }
}
