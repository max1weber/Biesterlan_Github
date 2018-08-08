using BiesterlanOrders.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiesterlanOrders.Services.Interfaces
{
    public interface IArticleService
    {


        List<Article> GetAllArticles();

        List<Article> GetActiveArticles();



    }
}
