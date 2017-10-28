using Chat.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;

namespace Chat.Data.Classes
{
    class MessageThreadDataAccess : IMessageThreadDataAccess
    {
        private ChatDBContext context;

        public MessageThreadDataAccess(ChatDBContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            MessageThread messageThread = this.context.MessageThreads.SingleOrDefault(x => x.ThreadId == id);
            this.context.MessageThreads.Remove(messageThread);

            return this.context.SaveChanges();
        }

        public MessageThread Get(int id)
        {
            return this.context.MessageThreads.SingleOrDefault(x => x.ThreadId == id);
        }

        public IEnumerable<MessageThread> GetAll()
        {
            return this.context.MessageThreads.ToList();
        }

        public int Insert(MessageThread messageThread)
        {
            this.context.MessageThreads.Add(messageThread);
            this.context.SaveChanges();
            return messageThread.ThreadId;
        }

        public int Update(MessageThread messageThread)
        {
            MessageThread updatedMessageThread = this.context.MessageThreads.SingleOrDefault(x => x.ThreadId == messageThread.ThreadId);
            
            return this.context.SaveChanges();
        }
    }
}
