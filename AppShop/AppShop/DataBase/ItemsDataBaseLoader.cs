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
            ItemsDataBase itemsDataBase = new ItemsDataBase();
            itemsDataBase.Name = "Ноутбук";
            itemsDataBase.price = 29999;
            itemsDataBase.oldprice = 39999;
            itemsDataBase.Id = 0;
            itemsDataBase.Description = "Самый крутой наутбук он очень хороший и кайфовый";
            itemsDataBase.Type = "Пк и перефирия";
            itemsDataBase.stock = true;
            itemsDataBase.icon = ImageSource.FromFile("pc.jpg");

            ItemsDataBase itemsDataBase2 = new ItemsDataBase();
            itemsDataBase2.Name = "Миниатюрные розы";
            itemsDataBase2.Id = 1;
            itemsDataBase2.Description = "Красивые розы для вашей любимой спальни";
            itemsDataBase2.Type = "Пк и перефирия";
            itemsDataBase2.price = 150;
            itemsDataBase2.oldprice = 169;
            itemsDataBase2.stock = true;

            ItemsDataBase itemsDataBase3 = new ItemsDataBase();
            itemsDataBase3.Name = "Телефон Poco x3 Pro";
            itemsDataBase3.Id = 2;
            itemsDataBase3.Description = "Телефон для лучшего подогрева ваших булочек";
            itemsDataBase3.Type = "Телефон";
            itemsDataBase3.price = 19999;
            itemsDataBase3.stock = false;

            items.Add(itemsDataBase2);
            items.Add(itemsDataBase);

        }

        List<ItemsDataBase> items = new List<ItemsDataBase>();

        
        public ItemsDataBase LoadItem(string name,bool stock)
        {
            ItemsDataBase item = new ItemsDataBase();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    if (items[i].stock = stock)
                    {
                        item = items[i];
                        break;
                    }
                }
            }
            return item;
        }
    }
}
