using Chat.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;
using Chat.Data.Interfaces;

namespace Chat.Service.Classes
{
    class MessageService : IMessageService
    {
        private IMessageDataAccess data;

        public MessageService(IMessageDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public Message Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<Message> GetAll()
        {
            return this.data.GetAll();
        }

        public IEnumerable<Message> GetByThreadId(int threadId)
        {
            return this.data.GetByThreadId(threadId);
        }

        public int Insert(Message message)
        {
            return this.data.Insert(message);
        }

        public int Update(Message message)
        {
            return this.data.Update(message);
        }
    }
}
