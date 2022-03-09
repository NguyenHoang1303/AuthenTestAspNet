using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationApp.Models
{
    public class User: IdentityUser
    {
       
        public string IdentityNumber { get; set; }
        public int Status { get; set; }

    }
}