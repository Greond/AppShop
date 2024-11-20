using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;
using Newtonsoft.Json;

namespace AppShop.DataBase.DataModels
{
    public class Item
    {
        [PrimaryKey]
        [JsonProperty("id")]
        public ulong ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("productType")]
        public string ProductType { get; set; }
        [JsonProperty("price")]
        public double? Price { get; set; }
        [JsonProperty("oldPrice")]
        public double? OldPrice { get; set; }
        [JsonProperty("stock")]
        public bool? Stock { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("stars")]
        public int? Stars { get; set; }
        [JsonProperty("rewiewsCount")]
        public int? ReviewsCount { get; set; }
        [JsonProperty("images")]
        public string Images { get; set; }
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
        [JsonProperty("mainDescription")]
        public string MainDescription { get; set; }
        [JsonProperty("specifications")]
        public string Specifications { get; set; }
    }
}
