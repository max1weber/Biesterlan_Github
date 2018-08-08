using BiesterlanOrders.Models;
using BiesterlanOrders.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.ViewModels
{
   public class UserViewModel
    {

        
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }


        public Uri ImageSource
        {

            get { return App.fileService.GetUserImageFileUrl(User.ID); }
        }

    }
}
