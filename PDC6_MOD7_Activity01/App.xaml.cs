﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC6_MOD7_Activity01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.EmployeeView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
