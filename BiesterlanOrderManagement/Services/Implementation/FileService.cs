using BiesterlanOrders.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BiesterlanOrders.Services.Implementation
{
    public class FileService : IFileService
    {

        private static string baseurl = string.Empty;
        public FileService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            baseurl = configuration["FileServer:baseurl"];
        }
        public Uri GetArticleImageFileUrl(Guid id)
        {

            var endpoint = string.Format("{0}/files/GetUserImageFile/{1}", baseurl, id.ToString());
            return new Uri(endpoint);
        }

        public Uri GetUserImageFileUrl(Guid id)
        {
            var endpoint = string.Format("{0}/files/GetArticleImage/{1}", baseurl, id.ToString());
            return new Uri(endpoint);
        }
    }
}
