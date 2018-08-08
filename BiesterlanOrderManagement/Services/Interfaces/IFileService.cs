using System;
using System.Collections.Generic;
using System.Text;

namespace BiesterlanOrders.Services.Interfaces
{
    public interface IFileService
    {
        Uri GetUserImageFileUrl(Guid id);

        Uri GetArticleImageFileUrl(Guid id);

    }
}
