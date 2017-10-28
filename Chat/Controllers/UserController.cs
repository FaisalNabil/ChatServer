using Chat.Entity;
using Chat.Models;
using Chat.Service;
using Chat.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        IUserService userService = ServiceFactory.GetUserService();
        IMessageThreadService messageThreadService = ServiceFactory.GetMessageThreadService();
        IThreadParticipantService threadParticipantService = ServiceFactory.GetThreadParticipantService();
        IMessageService messageService = ServiceFactory.GetMessageService();
        IMessageReadStatusService messageReadStatusService = ServiceFactory.GetMessageReadStatusService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SideBar()
        {
            return PartialView("_SideBar",userService.GetAll());
        }

        [HttpGet]
        public ActionResult ChatWindow(int userId)
        {
            ModelMessaging modelMessaging = new ModelMessaging();
            modelMessaging.ReceiverId = userId;

            User u1 = userService.Get(Convert.ToInt32(Session["LoggedInUser"]));
            User u2 = userService.Get(modelMessaging.ReceiverId);

            int existingThreadId = threadParticipantService.hasThread(u1.UserId, u2.UserId);

            if (existingThreadId == 0)
            {
                return View(modelMessaging);
            }
            else
            {
                modelMessaging.MessagesList = messageService.GetByThreadId(existingThreadId);
                foreach (var item in modelMessaging.MessagesList)
                {
                    if(!messageReadStatusService.isInRead(item.MessageId, Convert.ToInt32(Session["LoggedInUser"])))
                    {
                        MessageReadStatus messageReadStatus = new MessageReadStatus();
                        messageReadStatus.MessageMessageId = item.MessageId;
                        messageReadStatus.ReadDate = DateTime.Now.ToString();
                        messageReadStatus.UserUserId = Convert.ToInt32(Session["LoggedInUser"]);
                        messageReadStatusService.Insert(messageReadStatus);
                    }
                }

                return View(modelMessaging);
            }
            
        }

        [HttpPost]
        public ActionResult ChatWindow(ModelMessaging modelMessaging)
        {
            User u1 = userService.Get(Convert.ToInt32(Session["LoggedInUser"]));
            User u2 = userService.Get(modelMessaging.ReceiverId);

            int existingThreadId = threadParticipantService.hasThread(u1.UserId, u2.UserId);

            if (existingThreadId == 0)
            {
                //new thread create
                MessageThread messageThread = new MessageThread();

                //insert thread to database and retrieve thread id
                int threadId = messageThreadService.Insert(messageThread);

                //two new participants created
                ThreadParticipant user1 = new ThreadParticipant();
                ThreadParticipant user2 = new ThreadParticipant();

                //participant1 inserted in database for that thread id
                user1.MessageThreadThreadId = threadId;
                user1.UserUserId = u1.UserId;
                threadParticipantService.Insert(user1);

                //participant1 inserted in database for that thread id
                user2.MessageThreadThreadId = threadId;
                user2.UserUserId = u2.UserId;
                threadParticipantService.Insert(user2);

                //Message inserted in thread
                Message message = new Message();
                message.MessageBody = modelMessaging.newMessage;
                message.SendDate = DateTime.Now.ToString();
                message.UserUserId = u1.UserId;
                message.MessageThreadThreadId = threadId;
                messageService.Insert(message);
            }
            else
            {
                Message message = new Message();
                message.MessageBody = modelMessaging.newMessage;
                message.SendDate = DateTime.Now.ToString();
                message.UserUserId = u1.UserId;
                message.MessageThreadThreadId = existingThreadId;
                int messageId=messageService.Insert(message);

                MessageReadStatus messageReadStatus = new MessageReadStatus();
                messageReadStatus.MessageMessageId = messageId;
                messageReadStatus.ReadDate = DateTime.Now.ToString();
                messageReadStatus.UserUserId = Convert.ToInt32(Session["LoggedInUser"]);
                messageReadStatusService.Insert(messageReadStatus);
            }

            return RedirectToAction("ChatWindow", "User", new { userId= modelMessaging.ReceiverId });
        }
    }
}