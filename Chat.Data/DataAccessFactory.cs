using Chat.Data.Classes;
using Chat.Data.Interfaces;
using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data
{
    public abstract class DataAccessFactory
    {
        public static IUserDataAccess GetUserDataAccess()
        {
            return new UserDataAccess(new ChatDBContext());
        }

        public static IMessageDataAccess GetMessageDataAccess()
        {
            return new MessageDataAccess(new ChatDBContext());
        }

        public static IMessageThreadDataAccess GetMessageThreadDataAccess()
        {
            return new MessageThreadDataAccess(new ChatDBContext());
        }

        public static IMessageReadStatusDataAccess GetMessageReadStatusDataAccess()
        {
            return new MessageReadStatusDataAccess(new ChatDBContext());
        }

        public static IThreadParticipantDataAccess GetThreadParticipantDataAccess()
        {
            return new ThreadParticipantDataAccess(new ChatDBContext());
        }
    }
}
