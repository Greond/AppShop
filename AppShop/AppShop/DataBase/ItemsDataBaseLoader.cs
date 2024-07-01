using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace AppShop.DataBase
{
    class ItemsDataBaseLoader
    {
        public ItemsDataBaseLoader()  // ДА ДА, Я потом перенесу это всё в базу данных, это не сложно!,это просто для теста
        {
            ItemsData itemsDataBase = new ItemsData();
            itemsDataBase.Name = "Ноутбук ASUS ExpertBook";
            itemsDataBase.Price = 29999;
            itemsDataBase.OldPrice = 39999;
            itemsDataBase.ID ="0";
            itemsDataBase.Description = "Самый крутой наутбук он очень хороший и кайфовый";
            itemsDataBase.Type = ProDuctType.TechnicalHard;
            itemsDataBase.Stock = true;
            itemsDataBase.Icon = ImageSource.FromFile("pc.png");
            itemsDataBase.Stars = 0;
            itemsDataBase.ReviewsCount = 0;
            itemsDataBase.Images = new List<string>
            {
                "https://c.dns-shop.ru/thumb/st1/fit/500/500/f950fb0f02723c30971944f464aa4f4b/d065296ca332902431cdc02b37f7b75b1b18225916126c43884910039d29344e.jpg.webp",
                "https://c.dns-shop.ru/thumb/st1/fit/500/500/c91ddc22dfb166d46e415c3d90d9e534/26a4446db6bee1ad8d2a4765b04699ea285233f0eae3fdfc38b87a8faa7f5cf2.jpg.webp",
                "https://c.dns-shop.ru/thumb/st1/fit/500/500/d6b4386d577091108cbe300812d337de/e9241aead2de082304349be771877ff10338f2c9a49ddd97b0e310db11461da8.jpg.webp"
            };
            itemsDataBase.Quantity = 0;
            itemsDataBase.MainDescription = "Этот ноутбук создан для тех," +
                " кто хочет получить качественное и " +
                "производительное компьютерное устройство с наиболее востребованным функционалом." +
                " Данная модель полностью удовлетворяет данные требования. " +
                "Надежный накопитель предоставляет вам возможности для долговременного хранения необходимой виртуальной информации." +
                " Устройство оборудовано веб-камерой и микрофоном," +
                " благодаря которым вы сможете организовывать видеоконференции с партнерами по бизнесу и коллегами по работе.";
            itemsDataBase.Specifications = "Линейка: ExpertBook\r\nТип: ноутбук\r\nТип видеокарты: встроенная\r\nПроизводитель: ASUS";
            

            ItemsData itemsDataBase2 = new ItemsData();
            itemsDataBase2.Name = "Миниатюрные розы";
            itemsDataBase2.ID = "1";
            itemsDataBase2.Description = "Красивые розы для вашей любимой спальни";
            itemsDataBase2.Type = ProDuctType.Household;
            itemsDataBase2.Price = 150;
            itemsDataBase2.OldPrice = 169;
            itemsDataBase2.Stock = true;
            itemsDataBase2.Icon = ImageSource.FromFile("rose.png");
            itemsDataBase2.Stars = 0;
            itemsDataBase2.ReviewsCount = 0;
            itemsDataBase2.Images = new List<string>
            {
                "https://ir.ozone.ru/s3/multimedia-1/wc1000/6273358981.jpg",
                "https://ir.ozone.ru/s3/multimedia-3/wc1000/6273358983.jpg",
                "https://ir.ozone.ru/s3/multimedia-b/wc1000/6273360863.jpg"
            };
            itemsDataBase2.Quantity = 0;
            itemsDataBase2.MainDescription = "Эти изящные цветы для декора станут великолепным акцентом в любых композициях," +
                " создавая атмосферу уюта и изысканности. В наборе содержится 24 розочки," +
                " каждая из которых выполнена с высоким уровнем детализации, " +
                "что позволяет использовать их как цветы для рукоделия и украшений." +
                " Независимо от того, создаете ли вы свадебные букеты, поздравительные открытки," +
                " украшения для подарков или просто хотите добавить нотку элегантности в ваш дом, " +
                "эти цветы из бумаги станут незаменимыми помощниками в воплощении ваших творческих " +
                "идей. Мягкие и одновременно прочные, они легко поддаются фиксации, что позволяет надежно закрепить их в любом проекте." +
                " Благодаря компактному размеру, букетик роз из бумаги можно использовать как для крупных," +
                " так и для миниатюрных декоративных элементов." +
                " Подарите своим изделиям романтичное и нежное очарование с этими изысканными бумажными розочками от Skroll," +
                " которые идеально подходят для любого случая и станут незаменимой частью вашего творческого арсенала.";
            itemsDataBase2.Specifications = "Материал: Бумага\r\nРазмер: 10*30см\r\nВес: 20г";

            ItemsData itemsDataBase3 = new ItemsData();
            itemsDataBase3.Name = "Телефон Poco x3 Pro";
            itemsDataBase3.ID = "2";
            itemsDataBase3.Description = "Телефон для лучшего подогрева ваших булочек";
            itemsDataBase3.Type = ProDuctType.TechnicalHard;
            itemsDataBase3.Price = 19999;
            itemsDataBase3.Stock = false;
            itemsDataBase3.Icon = ImageSource.FromFile("mobilephone.png");
            itemsDataBase3.Stars = 0;
            itemsDataBase3.ReviewsCount = 0;
            itemsDataBase3.Images = new List<string>
            {
                "https://ir.ozone.ru/s3/multimedia-1-s/wc1000/7042594852.jpg",
                "https://ir.ozone.ru/s3/multimedia-1-v/wc1000/7042594855.jpg",
                "https://ir.ozone.ru/s3/multimedia-1-7/wc1000/7042594867.jpg"
            };
            itemsDataBase3.Quantity = 0;
            itemsDataBase3.MainDescription = "krytoy telephone";
            itemsDataBase3.Specifications = "Экран: 6.67\" (2400x1080) IPS 120 Гц\r\nФото: 4 камеры, основная 48 МП\r\nАккумулятор: 5160 мА·ч\r\nОперационная система: Android 11\r\nСтандарт связи: 4G LTE, 3G, 2G\r\nСтепень защиты: IP54, IP53\r\nВес: 215 г";

            items.Add(itemsDataBase3);
            items.Add(itemsDataBase2);
            items.Add(itemsDataBase);

        }

        List<ItemsData> items = new List<ItemsData>();

        
        public ItemsData LoadItem(string ID)
        {
            ItemsData item = new ItemsData();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == ID)
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
                if (items[i].Stock)
                {
                    itemsinstock.Add(items[i]);
                }
            }
            return itemsinstock;

        }
    }
}
