using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiesterlanOrders.Services.Implementation
{
    public abstract class BaseService: IDisposable
    {
       internal BiesterlanDbContext db;

        public BaseService()
        {
            if (db == null)
            {
                DesignTimeDbContextFactory factory = new DesignTimeDbContextFactory();
                db = factory.CreateDbContext(null);
            }

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
