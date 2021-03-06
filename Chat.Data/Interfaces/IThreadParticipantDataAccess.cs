﻿using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Interfaces
{
    public interface IThreadParticipantDataAccess
    {
        IEnumerable<ThreadParticipant> GetAll();
        ThreadParticipant Get(int id);
        int Insert(ThreadParticipant threadParticipant);
        int Update(ThreadParticipant threadParticipant);
        int Delete(int id);
        int hasThread(int user1, int user2);
    }
}
