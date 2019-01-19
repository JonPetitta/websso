using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Identity
    {
        public string LoginId { get; set; }
        public List<string> Roles { get; set; }
    }
}