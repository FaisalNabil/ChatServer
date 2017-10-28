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
    class ThreadParticipantService : IThreadParticipantService
    {
        private IThreadParticipantDataAccess data;

        public ThreadParticipantService(IThreadParticipantDataAccess data)
        {
            this.data = data;
        }

        public int Delete(int id)
        {
            return this.data.Delete(id);
        }

        public ThreadParticipant Get(int id)
        {
            return this.data.Get(id);
        }

        public IEnumerable<ThreadParticipant> GetAll()
        {
            return this.data.GetAll();
        }

        public int Insert(ThreadParticipant threadParticipant)
        {
            return this.data.Insert(threadParticipant);
        }

        public int Update(ThreadParticipant threadParticipant)
        {
            return this.data.Update(threadParticipant);
        }

        public int hasThread(int user1, int user2)
        {
            return this.data.hasThread(user1, user2);
        }
    }
}
