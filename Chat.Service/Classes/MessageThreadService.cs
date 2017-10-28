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
    class MessageThreadService : IMessageThreadService
    {
        private IMessageThreadDataAccess data;

        public MessageThreadService(IMessageThreadDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public MessageThread Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<MessageThread> GetAll()
        {
            return this.data.GetAll();
        }

        public int Insert(MessageThread messageThread)
        {
            return this.data.Insert(messageThread);
        }

        public int Update(MessageThread messageThread)
        {
            return this.data.Update(messageThread);
        }
    }
}
