using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileAppDemo
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void NavigateToSecondPage (object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }
}

