using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ContactDate => DateTime.Now.Date;
    }
}
