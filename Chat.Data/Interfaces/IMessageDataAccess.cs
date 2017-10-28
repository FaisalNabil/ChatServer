using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Interfaces
{
    public interface IMessageDataAccess
    {
        IEnumerable<Message> GetAll();
        Message Get(int id);
        int Insert(Message message);
        int Update(Message message);
        int Delete(int id);
        IEnumerable<Message> GetByThreadId(int threadId);
    }
}
