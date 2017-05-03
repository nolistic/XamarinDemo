﻿/**
 * A view model for the itemsdetail page.
 * **/
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using wenslerh.Helpers;
using wenslerh.Models;
using wenslerh.Views;

using Xamarin.Forms;

namespace wenslerh.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {

        public Item Item { get; set; }
        public ItemDetailViewModel()
        {

            Title = "Item Details";

            var name = new Entry();
            name.SetBinding(Entry.TextProperty, "Name");

            var description = new Entry();
            description.SetBinding(Entry.TextProperty, "Description");

            var strength = new Entry();
            strength.SetBinding(Entry.TextProperty, "Strength");

        }

        public ItemDetailViewModel(Item i)
        {
            Item = i;
        }
        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}