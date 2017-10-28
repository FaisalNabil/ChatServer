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
    class MessageReadStatusService : IMessageReadStatusService
    {
        private IMessageReadStatusDataAccess data;

        public MessageReadStatusService(IMessageReadStatusDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public MessageReadStatus Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<MessageReadStatus> GetAll()
        {
            return this.data.GetAll();
        }

        public int Insert(MessageReadStatus messageReadStatus)
        {
            return this.data.Insert(messageReadStatus);
        }

        public bool isInRead(int messageId, int userId)
        {
            return this.data.isInRead(messageId, userId);
        }

        public int Update(MessageReadStatus messageReadStatus)
        {
            return this.data.Update(messageReadStatus);
        }
    }
}
