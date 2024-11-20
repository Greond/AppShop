using System.Collections.Generic;
using Xamarin.Forms;
using AppShop.DataBase.DataModels;
using System.Threading.Tasks;
using System;
using System.Data;
using SQLite;
using SQLitePCL;
using Xamarin.Essentials;
using System.Linq;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.CommunityToolkit.Converters;
using System.IO;
namespace AppShop.DataBase
{
    public class ItemsDB
    {
        private static SQLiteAsyncConnection db;
        public ItemsDB(string connectionString)  // ппц, это было сложно
        {

            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<Item>().Wait();
           // TryUpdateLocalDB();
        }

        public Task<List<Item>> GetItemsInStockAsync()
        {
            return db.Table<Item>().Where( i => i.Stock == true).ToListAsync();
        }
        public Task<List<Item>> GetItemsAsync()
        {
            return db.Table<Item>().ToListAsync();
        }
        public Task<Item> GetItemAsync(int id)
        {
            return db.Table<Item>().Where(i => i.ID == (ulong)id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0)
            {
                return db.UpdateAsync(item);
            }
            else
            {
                return db.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(Item item)
        {
            return db.DeleteAsync(item);
        }
        public Task<int> UpdateTableAsync(IEnumerable<Item> items)
        {
            db.DeleteAllAsync<Item>();
            return db.InsertAllAsync(items);
        }

       
    }
}
