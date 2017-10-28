using Chat.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;

namespace Chat.Data.Classes
{
    class MessageDataAccess : IMessageDataAccess
    {
        private ChatDBContext context;

        public MessageDataAccess(ChatDBContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            Message message = this.context.Messages.SingleOrDefault(x => x.MessageId == id);
            this.context.Messages.Remove(message);

            return this.context.SaveChanges();
        }

        public Message Get(int id)
        {
            return this.context.Messages.SingleOrDefault(x => x.MessageId == id);
        }

        public IEnumerable<Message> GetAll()
        {
            return this.context.Messages.ToList();
        }

        public IEnumerable<Message> GetByThreadId(int threadId)
        {
            return this.context.Messages.Where(x => x.MessageThreadThreadId == threadId).ToList();
        }

        public int Insert(Message message)
        {
            this.context.Messages.Add(message);
            this.context.SaveChanges();

            return message.MessageId;
        }

        public int Update(Message message)
        {
            Message updatedMessage = this.context.Messages.SingleOrDefault(x => x.MessageId == message.MessageId);

            updatedMessage.MessageBody = message.MessageBody;
            updatedMessage.SendDate = message.SendDate;
            updatedMessage.UserUserId = message.UserUserId;

            return this.context.SaveChanges();
        }
    }
}
