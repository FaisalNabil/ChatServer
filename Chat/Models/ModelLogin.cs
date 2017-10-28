using Chat.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ModelLogin : User
    {
        public string ErrorMessage { get; set; }
    }
}