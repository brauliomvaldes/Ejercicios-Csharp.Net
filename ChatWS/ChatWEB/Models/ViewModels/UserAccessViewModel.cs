using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UtilityChat.Models.WS;

namespace ChatWEB.Models.ViewModels
{
    public class UserAccessViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }


    }
}