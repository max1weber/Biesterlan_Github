using BiesterlanOrders.Models;
using BiesterlanOrders.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiesterlanOrders.Services.Implementation
{
    public class ArticleService :BaseService, IArticleService
    {
        private bool _isTest = false;

        private List<Article> currentArticles;
        public ArticleService()
        {

        }

        public ArticleService( bool istest)
        {
            _isTest = istest;
        }

        public List<Article> GetActiveArticles()
        {
            var result = GetAllArticles();
            return result.Where(p => p.IsActive==true).ToList();
        }

        public List<Article> GetAllArticles()
        {

            if (currentArticles == null)
            {
                currentArticles = new List<Article>();
                if (_isTest)
                {
                    Random random = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        Article article = new Article();
                        article.IsActive = true;
                        article.Name = "Drinken " + i.ToString();
                        article.SalesPrice =(Decimal) (random.NextDouble() * (10 + i));
                        currentArticles.Add(article);
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        Article article = new Article();
                        article.IsActive = true;
                        article.ArticleGroup = ArticleGroup.Eten;
                        article.Name = "Eten " + i.ToString();
                        article.SalesPrice = (Decimal)(random.NextDouble() * (10 + i));
                        currentArticles.Add(article);
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        Article article = new Article();
                        article.IsActive = true;
                        article.Name = "Overig " + i.ToString();
                        article.ArticleGroup = ArticleGroup.Overig;
                        article.SalesPrice = (Decimal)(random.NextDouble() * (10 + i));
                        currentArticles.Add(article);
                    }



                }


                var result = db.Articles.Where(p=>p.IsActive == true).ToList();
                currentArticles.AddRange(result);
            }
            
            return currentArticles;
        }
    }
}
