using System;
using System.Collections.Generic;

#nullable disable

namespace ContactsAppWPF.Models
{
    public partial class Contact
    {
        public int ContactsId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
