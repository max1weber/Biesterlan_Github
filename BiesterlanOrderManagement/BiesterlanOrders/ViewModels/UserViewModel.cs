using BiesterlanOrders.Models;
using BiesterlanOrders.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace BiesterlanOrders.ViewModels
{
   public class UserViewModel
    {

        
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }


        public BitmapImage ImageSource
        {
            get {
                var endpoint = App.fileService.GetUserImageFileUrl(User.ID);
                var bitmapImage = new BitmapImage() { UriSource = endpoint };

                return bitmapImage;
            
            }
        }

    }
}
