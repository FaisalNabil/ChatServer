using Chat.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;

namespace Chat.Data.Classes
{
    class MessageReadStatusDataAccess : IMessageReadStatusDataAccess
    {
        private ChatDBContext context;

        public MessageReadStatusDataAccess(ChatDBContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            MessageReadStatus messageReadStatus = this.context.MessageReadStatus.SingleOrDefault(x => x.MessageReadStatusId == id);
            this.context.MessageReadStatus.Remove(messageReadStatus);

            return this.context.SaveChanges();
        }

        public MessageReadStatus Get(int id)
        {
            return this.context.MessageReadStatus.SingleOrDefault(x => x.MessageReadStatusId == id);
        }

        public IEnumerable<MessageReadStatus> GetAll()
        {
            return this.context.MessageReadStatus.ToList();
        }

        public int Insert(MessageReadStatus messageReadStatus)
        {
            this.context.MessageReadStatus.Add(messageReadStatus);
            return this.context.SaveChanges();
        }

        public bool isInRead(int messageId, int userId)
        {
            var readStatus= this.context.MessageReadStatus.SingleOrDefault(x => x.MessageMessageId == messageId && x.UserUserId==userId);
            if (readStatus == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int Update(MessageReadStatus messageReadStatus)
        {
            MessageReadStatus updatedMessageReadStatus = this.context.MessageReadStatus.SingleOrDefault(x => x.MessageReadStatusId == messageReadStatus.MessageReadStatusId);

            updatedMessageReadStatus.ReadDate = messageReadStatus.ReadDate;

            return this.context.SaveChanges();
        }
    }
}
