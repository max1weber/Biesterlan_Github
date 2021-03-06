﻿using BiesterlanOrders.Models;
using BiesterlanOrders.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BiesterlanOrders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyOrders : Page
    {
        private NavigationEventArgs nea;

        private UserViewModel selecteduser;
        public List<UserOrderView> orderlines { get; set; }

        public decimal TotalAmount { get; set; }



        public MyOrders()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            nea = e;
            UserViewModel userid = (UserViewModel)e.Parameter;

            selecteduser = userid;

            base.OnNavigatedTo(e);

            BackButton.IsEnabled = this.Frame.CanGoBack;

            InitOrderLines();



        }

        private void InitOrderLines()
        {
           orderlines = App.userService.GetUserOrders(selecteduser.User.ID);

            List<UserOrderView> aggregatedorders = orderlines
                .GroupBy(l => l.ArticleName)
                .Select(cl => new UserOrderView
                {
                    ArticleName = cl.First().ArticleName,
                    SalesPrice = cl.First().SalesPrice,
                    Amount = cl.Sum(c => c.Amount),
                    LineTotal = cl.Sum(c => c.LineTotal)
                }).ToList();

            orderlines = aggregatedorders;
            TotalAmount = orderlines.Sum(p => p.LineTotal);

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            selecteduser = null;
            base.OnNavigatedFrom(e);



        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }


        // Handles system-level BackRequested events and page-level back button Click events
        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }
    }
}
