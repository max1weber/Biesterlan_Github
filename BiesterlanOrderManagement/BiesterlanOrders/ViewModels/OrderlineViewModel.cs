using BiesterlanOrders.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace BiesterlanOrders.ViewModels
{
    public class OrderlineViewModel
    {

        public OrderlineViewModel(Article article)
        {
            Article = article;
        }
        [Range(1,10, ErrorMessage ="Minimum is 1 & maximum is 10")]
        public int Amount { get; set; } = 0;


       public  Article Article { get; set; }


        //public BitmapImage GetBitMapSource
        //{
        //    get
        //    {
        //        Image img = new Image();
        //        BitmapImage bitmapImage = new BitmapImage();
        //        Uri uri = new Uri(string.Format("file:///{0}", this.Article.ImagePath));
        //        bitmapImage.UriSource = uri;
        //        return bitmapImage;
        //    }

        //}

        public Orderline GetOrderLine(Order order)
        {

            if (Amount == 0)
            { return null; }
            else
            {
                Orderline orderline = new Orderline();
                orderline.ArticleID = Article.ID;
                orderline.Name = Article.Name;
                orderline.Amount = Amount;
                orderline.SalesPrice = Article.SalesPrice;
                orderline.Order = order;
                return orderline;
            }

        }

    }
}
