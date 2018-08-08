using BiesterlanOrders.Models;
using BiesterlanOrders.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BiesterlanOrders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectArticlePage : Page
    {

      
        private NavigationEventArgs nea;

        private  UserViewModel selecteduser;
        private List<ViewModels.OrderlineViewModel> orderlines;
        public SelectArticlePage()
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
            if (orderlines == null)
            {
                orderlines = new List<ViewModels.OrderlineViewModel>();
                 App.articleService.GetActiveArticles().ForEach(o => {
                     OrderlineViewModel ovm = new OrderlineViewModel(o);
                     orderlines.Add(ovm);


                 }); 

            }
                


          
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

        private void SaveButtong_Click(object sender, RoutedEventArgs e)
        {

            Order order = new Order();

            //var orderuser =App.userService.GetActiveUsers().FirstOrDefault(p => p.ID.Equals(selecteduser.User.ID));

            order.UserId = selecteduser.User.ID;
            
            orderlines.Where(o => o.Amount > 0).ToList().ForEach(o =>
            {
                if (o.Amount > 0)
                {
                    Orderline orderline = o.GetOrderLine(order);
                    order.Orderlines.Add(orderline);
                }
            });
            App.orderService.SaveOrders(order);


            On_BackRequested();

        }

        private void MyOrders_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyOrders), selecteduser);
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage bitmapImage = new BitmapImage();

            Uri uri = new Uri("ms-appx:///Assets/Foodsmall.png");
            bitmapImage.UriSource = uri;
            img.Source = bitmapImage;
            img.Width = 150; //set to known width of this source's natural size
            img.Height = 150;
        }
    }
}
