using AppShop.ContentView;
using AppShop.DataBase.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShop.Converters
{
    static class ContentConverter
    {
        //подлежит к удалению
        static public List<ActionContentView> ConvertItemsToActionsViews(List<Item> items)
        {
            List<ActionContentView> actionContentViews = new List<ActionContentView>();
            foreach (Item item in items)
            {
                ActionContentView actionContentView = new ActionContentView();
                actionContentView.TitleText = item.Name;
                actionContentView.Describe = item.Description;
                actionContentView.ButtonText = "Подробнее";
                actionContentView.NewPrice = item.Price.ToString();
                actionContentView.OldPrice = item.OldPrice.ToString();
                actionContentView.ImageSource = item.Icon;
                actionContentView.IdItem = item.ID;
                actionContentView.ButtonCommandParameter = actionContentView;
                actionContentView.SetBinding(ActionContentView.ButtonCommandProperty, new Binding("ActionButtonClick"));

                actionContentViews.Add(actionContentView);
            }
            return actionContentViews;
        }
        static public StackLayout ConvertActionViewsToStackLayout(List<ActionContentView> actionContents, StackOrientation stackOrientation) 
        {
            StackLayout layout = new StackLayout();
            layout.Orientation = stackOrientation;
            foreach (ActionContentView actionContentView in actionContents)
            {
                layout.Children.Add(actionContentView);
            }
            return layout;
        }
    }
}
