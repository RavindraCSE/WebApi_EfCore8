using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class ValidateUserModel
    {
        public string EmailAddress { get; set; }
        public int UserId { get; set; }
        public string Roles { get; set; }
    }
}
