using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AppShop.DataBase.DataModels
{
    public class ItemCategory
    {
        [JsonProperty("id")]
        public long CategoryId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
