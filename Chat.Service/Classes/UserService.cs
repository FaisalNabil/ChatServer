using Chat.Data.Interfaces;
using Chat.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;

namespace Chat.Service.Classes
{
    class UserService : IUserService
    {
        private IUserDataAccess data;

        public UserService(IUserDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public User Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return this.data.GetAll();
        }

        public User GetByName(string name)
        {
            return this.data.GetByName(name);
        }

        public int Insert(User user)
        {
            return this.data.Insert(user);
        }

        public int Update(User user)
        {
            return this.data.Update(user);
        }
    }
}
