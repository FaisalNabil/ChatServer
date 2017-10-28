using Chat.Data;
using Chat.Service.Classes;
using Chat.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service
{
    public abstract class ServiceFactory
    {
        public static IUserService GetUserService()
        {
            return new UserService(DataAccessFactory.GetUserDataAccess());
        }

        public static IMessageService GetMessageService()
        {
            return new MessageService(DataAccessFactory.GetMessageDataAccess());
        }

        public static IMessageThreadService GetMessageThreadService()
        {
            return new MessageThreadService(DataAccessFactory.GetMessageThreadDataAccess());
        }

        public static IMessageReadStatusService GetMessageReadStatusService()
        {
            return new MessageReadStatusService(DataAccessFactory.GetMessageReadStatusDataAccess());
        }

        public static IThreadParticipantService GetThreadParticipantService()
        {
            return new ThreadParticipantService(DataAccessFactory.GetThreadParticipantDataAccess());
        }
    }
}
