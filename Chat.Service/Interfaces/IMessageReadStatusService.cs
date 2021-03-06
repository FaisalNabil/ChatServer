﻿using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Interfaces
{
    public interface IMessageReadStatusService
    {
        IEnumerable<MessageReadStatus> GetAll();
        MessageReadStatus Get(int id);
        int Insert(MessageReadStatus messageReadStatus);
        int Update(MessageReadStatus messageReadStatus);
        int Delete(int id);
        bool isInRead(int messageId, int userId);
    }
}
