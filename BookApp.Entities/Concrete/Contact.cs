using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ContactDate { get; set; }

    }
}
