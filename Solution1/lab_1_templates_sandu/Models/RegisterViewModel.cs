using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
	public class RegisterViewModel
	{
        public string password { get; set; }

        public string username { get; set; }
        public string email { get; set; }
        public string confirmPassword { get; set; }
    }
}