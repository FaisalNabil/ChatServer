﻿using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Service.Interfaces
{
    public interface IMessageThreadService
    {
        IEnumerable<MessageThread> GetAll();
        MessageThread Get(int id);
        int Insert(MessageThread messageThread);
        int Update(MessageThread messageThread);
        int Delete(int id);
    }
}
