using Chat.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chat.Models
{
    public class ModelUserRegistration : User
    {
        [CompareAttribute("UserPassword", ErrorMessage = "Password does not match!")]
        public String ConfirmPassword { get; set; }
        public String NotifyAccountCreatedStatus { get; set; }
        public string UserExistMessage { get; set; }
    }
}