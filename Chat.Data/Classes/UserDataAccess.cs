using Chat.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;

namespace Chat.Data.Classes
{
    class UserDataAccess : IUserDataAccess
    {
        private ChatDBContext context;

        public UserDataAccess(ChatDBContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            User user=this.context.Users.SingleOrDefault(x => x.UserId == id);
            this.context.Users.Remove(user);

            return this.context.SaveChanges();
        }

        public User Get(int id)
        {
            return this.context.Users.SingleOrDefault(x => x.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public User GetByName(string name)
        {
            return this.context.Users.SingleOrDefault(x => x.UserName == name);
        }

        public int Insert(User user)
        {
            this.context.Users.Add(user);
            return this.context.SaveChanges();
        }

        public int Update(User user)
        {
            User updatedUser = this.context.Users.SingleOrDefault(x => x.UserId == user.UserId);

            updatedUser.UserName = user.UserName;
            updatedUser.UserPassword = user.UserPassword;
            updatedUser.UserEmail = user.UserPassword;
            updatedUser.dateCreated = user.dateCreated;
            updatedUser.isActive = user.isActive;

            return this.context.SaveChanges();
        }
    }
}
