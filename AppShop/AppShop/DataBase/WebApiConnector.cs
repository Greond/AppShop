using AppShop.DataBase.DataModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Essentials;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;

namespace AppShop.DataBase
{
    public static class WebApiConnector
    {
        // https://192.168.1.101:7274/api
         public static string BaseUrl = Preferences.Get("BaseUrl", "https://192.168.1.101:7274/api");
        public static async Task<Item> GetItemById(ulong ID)
        {
            if (!WiFiConnection()) // Проверка на Wi-Fi подключение
            {
                throw new Exception("Неверное подключение к интернету. Требуеться домашная Wi-Fi");
            }
            string url = BaseUrl + "/Items" + $"/{ID}";
            Item item = new Item();
            try
            {
                Console.WriteLine("Try connect to WebApi");
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                HttpClient client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                Console.WriteLine(response.Content);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка
                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(content);
                item = JsonConvert.DeserializeObject<Item>(obj.ToString());

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static async Task<List<Item>> GetItemsFromWebApi(string? propertyName, string? propertyValue ,int? ItemsCount)
        {
            if(!WiFiConnection()) // Проверка на Wi-Fi подключение
            {
                throw new Exception("Неверное подключение к интернету. Требуеться домашная Wi-Fi");
            }
            string url = BaseUrl + "/Items";
            List<Item> items = new List<Item>();
            if (propertyName != null || propertyValue != "")
            {
                url += $"/ByProperty?{propertyName}={propertyValue}"; 
                // like a https://192.168.1.103:7274/api/Item/ByProperty?Stock=true
                if (ItemsCount > 0)
                {
                    url += $"&Count={ItemsCount}";
                }
            }
            try
            {
                Console.WriteLine("Try connect to WebApi");
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                HttpClient client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                Console.WriteLine(response.Content);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка
                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JArray arr = JArray.Parse(content);
                foreach (var item in arr)
                {
                    Item rcvdData = JsonConvert.DeserializeObject<Item>(item.ToString());
                    items.Add(rcvdData);
                }
                //seccuses
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static async Task<List<ItemCategory>> GetItemsCategories()
        {
            if (!WiFiConnection()) // Проверка на Wi-Fi подключение
            {
                throw new Exception("Неверное подключение к интернету. Требуеться домашная Wi-Fi");
            }
            string url = BaseUrl + "/Items/Categories";
            List<ItemCategory> Categories = new List<ItemCategory>();
            try
            {
                Console.WriteLine("Try connect to WebApi");
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // Pass the handler to httpclient(from you are calling api)
                HttpClient client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                Console.WriteLine(response.Content);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка
                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JArray arr = JArray.Parse(content);
                foreach (var category in arr)
                {
                    ItemCategory rcvdData = JsonConvert.DeserializeObject<ItemCategory>(category.ToString());
                    Categories.Add(rcvdData);
                }
                return Categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool WiFiConnection()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet || !Connectivity.ConnectionProfiles.Contains(ConnectionProfile.WiFi))
            {
                return false;
            }
            else if (Connectivity.ConnectionProfiles.Contains(ConnectionProfile.WiFi))
            {
                // если активно подключение через Wi-Fi
                return true;

            }
            return false;
        }
    }
}
