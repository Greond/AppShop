using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace AppShop.DataBase
{
    class ItemsDataBaseLoader
    {
        public ItemsDataBaseLoader() 
        {
            ItemsData itemsDataBase = new ItemsData();
            itemsDataBase.Name = "Ноутбук";
            itemsDataBase.price = 29999;
            itemsDataBase.oldprice = 39999;
            itemsDataBase.Id = 0;
            itemsDataBase.Description = "Самый крутой наутбук он очень хороший и кайфовый";
            itemsDataBase.Type = "Пк и перефирия";
            itemsDataBase.stock = true;
            itemsDataBase.icon = ImageSource.FromFile("pc.png");
            itemsDataBase.stars = 0;

            ItemsData itemsDataBase2 = new ItemsData();
            itemsDataBase2.Name = "Миниатюрные розы";
            itemsDataBase2.Id = 1;
            itemsDataBase2.Description = "Красивые розы для вашей любимой спальни";
            itemsDataBase2.Type = "Разное";
            itemsDataBase2.price = 150;
            itemsDataBase2.oldprice = 169;
            itemsDataBase2.stock = true;
            itemsDataBase2.icon = ImageSource.FromFile("rose.png");
            itemsDataBase2.stars = 0;

            ItemsData itemsDataBase3 = new ItemsData();
            itemsDataBase3.Name = "Телефон Poco x3 Pro";
            itemsDataBase3.Id = 2;
            itemsDataBase3.Description = "Телефон для лучшего подогрева ваших булочек";
            itemsDataBase3.Type = "Телефон";
            itemsDataBase3.price = 19999;
            itemsDataBase3.stock = false;
            itemsDataBase3.icon = ImageSource.FromFile("mobilephone.png");
            itemsDataBase3.stars = 0;

            items.Add(itemsDataBase3);
            items.Add(itemsDataBase2);
            items.Add(itemsDataBase);

        }

        List<ItemsData> items = new List<ItemsData>();

        
        public ItemsData LoadItem(long ID)
        {
            ItemsData item = new ItemsData();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == ID)
                {
                    item = items[i];
                    break;
                }
            }
            return item;
        }
        public List<ItemsData> LoadAllStockItem()
        {
            List<ItemsData> itemsinstock = new List<ItemsData>();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].stock)
                {
                    itemsinstock.Add(items[i]);
                }
            }
            return itemsinstock;

        }
    }
}
