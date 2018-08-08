using BiesterlanOrders.Models;
using BiesterlanOrders.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BiesterlanOrders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SelectUserPage : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            _items.Clear();
            var users = App.userService.GetActiveUsers().OrderBy(p=>p.Name).ToArray();

            for (int i  = 0; i  < users.Count(); i ++)
            {
                UserViewModel item = new UserViewModel(users[i]);

                _items.Add(item);
            }
            
        }

       


        private ObservableCollection<UserViewModel> _items = new ObservableCollection<UserViewModel>();

        public ObservableCollection<UserViewModel> Items
        {
            get { return this._items; }
        }

        public SelectUserPage()
        {
            this.InitializeComponent();
            
        }

      
        

        

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          UserViewModel selecteduserviewmodel =   e.AddedItems.FirstOrDefault() as UserViewModel;

            if (selecteduserviewmodel != null)
            {
                Frame.Navigate(typeof(SelectArticlePage), selecteduserviewmodel);
            }
        }

        private void BitmapImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage bitmapImage = new BitmapImage();
           
            Uri uri = new Uri("ms-appx:///Assets/NerdPlaceholder.png");
            bitmapImage.UriSource = uri;
            img.Source = bitmapImage;
            img.Width = 154; //set to known width of this source's natural size
            img.Height = 180;                 //might instead want image to stretch to fill, depends on scenario
            


        }
    }
}
