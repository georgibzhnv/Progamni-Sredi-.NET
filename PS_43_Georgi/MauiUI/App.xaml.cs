﻿namespace MauiUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.MainPage());
        }
    }
}
