using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace BiesterlanOrders.Models
{
    public class Article:BaseImageEntity
    {

        public Article()
        {
            ID = Guid.NewGuid();
        }

       

        [Required]
        public decimal SalesPrice { get; set; } = 1;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public ArticleGroup ArticleGroup { get; set; } = ArticleGroup.Drinken;

       
        [MaxLength(250)]
        public string ImageName { get; set; }
    }
}
