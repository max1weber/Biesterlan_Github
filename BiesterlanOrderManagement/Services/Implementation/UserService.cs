using BiesterlanOrders.Models;
using BiesterlanOrders.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiesterlanOrders.Services.Implementation
{
    public class UserService : BaseService,IUserService
    {
        List<User> currentUsers;

        bool IsTest = false;
        public UserService()
        {

        }

        public UserService(bool istest)
        {
            IsTest = istest;
        }
        public List<User> GetActiveUsers()
        {

            if (currentUsers == null)
            {
                currentUsers = new List<User>();
            }
            if (IsTest && currentUsers.Count == 0)
            {

                for (int i = 0; i < 30; i++)
                {
                    User newuser = new User() { Active = true, Name = "UserName " + i.ToString() };
                    currentUsers.Add(newuser);
                }
            }
            else if (currentUsers.Count == 0)
            {
                var result = db.Users.Where(p => p.Active == true).ToList();
                currentUsers.AddRange(result);

            }




            return currentUsers;
        }

        public List<Order> GetUserOrders(string username)
        {
            throw new NotImplementedException();
        }

        public List<UserOrderView> GetUserOrders(Guid? id)
        {
            if (id == null)
                return db.UserOrders.ToList();


            return db.UserOrders.Where(p => p.UserID == id).ToList();

            
        }

        public List<User> GetUsers(bool all)
        {
            throw new NotImplementedException();
        }
    }
}
