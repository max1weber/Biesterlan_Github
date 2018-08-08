using System;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdminWebUI.Controllers
{
    
    public class FilesController : ContextController
    {

       
        
        public FilesController(BiesterlanDbContext context, IConfiguration configuration):base(context,configuration)
        {
           
            
        }


        public FileResult GetFileFromBytes(byte[] bytesIn, string filename)
        {

            string extension = "png";
            try
            {
               extension= filename.Split('.')[1].Replace(".", "");
                
            }
            catch (Exception)
            {

                throw;
            }

           var contenttype= string.Format("image/{0}", extension);
            return File(bytesIn, contenttype, filename);
        }

        [HttpGet]
          public FileResult GetUserImageFile(Guid? id)
        {
            var user =  _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            FileResult imageUserFile = GetFileFromBytes(user.Image, user.ImageName);
            return imageUserFile;
        }
    }
}