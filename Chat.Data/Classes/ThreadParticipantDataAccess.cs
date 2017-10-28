using Chat.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Entity;

namespace Chat.Data.Classes
{
    class ThreadParticipantDataAccess : IThreadParticipantDataAccess
    {
        private ChatDBContext context;

        public ThreadParticipantDataAccess(ChatDBContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            ThreadParticipant threadParicipant = this.context.ThreadParticipants.SingleOrDefault(x => x.ThreadParticipantId == id);
            this.context.ThreadParticipants.Remove(threadParicipant);

            return this.context.SaveChanges();
        }

        public ThreadParticipant Get(int id)
        {
            return this.context.ThreadParticipants.SingleOrDefault(x => x.ThreadParticipantId == id);
        }

        public IEnumerable<ThreadParticipant> GetAll()
        {
            return this.context.ThreadParticipants.ToList();
        }

        public int hasThread(int user1, int user2)
        {
            int threadId;
            try
            {
                threadId = (from a in context.ThreadParticipants join b in context.ThreadParticipants on a.MessageThreadThreadId equals b.MessageThreadThreadId where a.UserUserId == user1 && b.UserUserId == user2 select a.MessageThreadThreadId).First();
                return threadId;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        public int Insert(ThreadParticipant threadParticipant)
        {
            this.context.ThreadParticipants.Add(threadParticipant);
            return this.context.SaveChanges();
        }

        public int Update(ThreadParticipant threadParticipant)
        {
            ThreadParticipant updatedThreadParticipant = this.context.ThreadParticipants.SingleOrDefault(x => x.ThreadParticipantId == threadParticipant.ThreadParticipantId);

            return this.context.SaveChanges();
        }
    }
}
