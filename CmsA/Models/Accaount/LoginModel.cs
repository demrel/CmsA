using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsA.Web.Models.Accaount;

    public class LoginModel
    {
        [Required(ErrorMessage = "login yazılmıyıb")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "parol yazılmıyıb")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Yadda Saxlamaq?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }

