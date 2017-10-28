using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User GetByName(string name);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
    }
}
